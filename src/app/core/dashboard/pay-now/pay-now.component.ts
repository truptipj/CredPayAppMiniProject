import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { CardService } from '../../service/card.service';
import { CardInfo } from '../CardInfo';

@Component({
  selector: 'app-pay-now',
  templateUrl: './pay-now.component.html',
  styleUrls: ['./pay-now.component.css']
})
export class PayNowComponent implements OnInit {

  creditCards: CardInfo[] = [];
  itemInfo:any;
  payForm:any= FormGroup;
  maxPayAmount : any;
  isUpdate:boolean = false;
  minAccBal : boolean  = false;
  cardBalance:any;
  selectedId:any;

  constructor(private router: Router, private fb: FormBuilder, private cardService: CardService) { }

  ngOnInit(): void {
    let product:any = (localStorage.getItem('selectetItem'));
    this.getAllCards();
    this.itemInfo = JSON.parse(product);
    console.log(this.itemInfo);
    this.payForm = this.fb.group({
      productName: [this.itemInfo.productName, [Validators.required, ]],
      category: [this.itemInfo.category, [Validators.required]],
      price: [this.itemInfo.price, [Validators.required]],
      amountPaid: ['', [Validators.required]],
      minDue: ['', [Validators.required]],
      cardDetailId: ['', [Validators.required]],
      isActive:[true]
    })

    if(this.itemInfo.cardDetailId){
      this.isUpdate = true;
      console.log(this.itemInfo.cardDetailId)
      this.maxPayAmount = this.itemInfo.minDue;
      this.cardBalance = this.itemInfo.balance;
      this.selectedId = parseInt(this.itemInfo.cardDetailId);
      this.payForm.controls.cardDetailId.setValue(this.selectedId)

    } else {
      this.maxPayAmount = this.itemInfo.price;
    }

  }
  get addCardsControl() { return this.payForm.controls; }

  checkMinDue(e:any){
    console.log(e.target.value);
    console.log(this.payForm.value.amountPaid);
    console.log(this.maxPayAmount);

      if(this.cardBalance && (this.cardBalance < this.payForm.value.amountPaid)) {
        this.minAccBal = true
      } else {
        this.minAccBal = false
      }

      if((this.payForm.value.amountPaid > this.maxPayAmount) || this.minAccBal) {
        this.payForm.controls['amountPaid'].reset();
        this.payForm.controls['minDue'].reset();
      } else {
        this.payForm.controls.minDue.setValue(this.maxPayAmount - this.payForm.value.amountPaid);
      }
  }
  changeType() {
    let seleObj:any;
    seleObj = this.creditCards.find(x => x.cardDetailId == this.payForm.value.cardDetailId);
    if(seleObj) {
      this.cardBalance = seleObj.balance;
      if(this.payForm.value.amountPaid > seleObj?.balance) {
        this.payForm.controls['amountPaid'].reset();
        this.payForm.controls['minDue'].reset();
        this.minAccBal =  true;
      } else {
        this.minAccBal =  false;
      }
    }



  }

  payNow(){
    console.log(this.payForm.value);

    let selectedCard:any;
    selectedCard = this.creditCards.find(item => item.cardDetailId == this.payForm.value.cardDetailId);
    console.log(selectedCard);
    this.payForm.value.status = true;

    if(!this.isUpdate) {
      let url = environment.baseUrl + 'Pay';
      this.cardService.payBill(url, this.payForm.value).subscribe((res) => {
        console.log(res);
        if (res) {
          this.updateCard();
          this.router.navigate(['/user/transact']);
        }
      });
    } else {
      let url = environment.baseUrl + 'Pay?id=' + this.itemInfo.payId;
      this.cardService.updateBill(url, this.payForm.value).subscribe((res) => {
        console.log(res);
        if (res) {
          this.updateCard();
          this.router.navigate(['/user/transact']);
        }
      });
    }

  }

  updateCard() {

    let card:any;
    card = this.creditCards.find((x:any) => {
      if(x.cardDetailId == this.payForm.value.cardDetailId) {
        return x.cardDetailId == this.payForm.value.cardDetailId
      } else {
        return null
      }
    });
    console.log(card);
    if(card) {
    console.log(card);
    card.balance = card.balance - this.payForm.value.amountPaid
    let url = environment.baseUrl + "CardDetails?id=" + card.cardDetailId;
    console.log(card);
    console.log(url);

     this.cardService.updateCard(url,card).subscribe((res)=>{
       if(res.result) {

       }
     })
    }

  }

  getAllCards() {
    let url = environment.baseUrl + "CardDetails";
    this.cardService.getCard(url).subscribe((res)=>{
      if(res) {
        this.creditCards = res;
      }
    })
  }

}
