import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { CardService } from '../../service/card.service';
export interface CardInfo {
  cardNumber: string,
  cardOwnerName: string,
  userId: number,
  balace: number,
  bank: string,
  expirationDate: Date,
  cvv: number,
  cardDetailId:number
}
@Component({
  selector: 'app-pay-now',
  templateUrl: './pay-now.component.html',
  styleUrls: ['./pay-now.component.css']
})
export class PayNowComponent implements OnInit {

  creditCards: CardInfo[] = [];
  itemInfo:any;
  payForm:any= FormGroup;

  constructor(private router: Router, private fb: FormBuilder, private cardService: CardService) { }

  ngOnInit(): void {
    this.itemInfo = (localStorage.getItem('selectetItem'));
    this.getAllCards();
    let product = JSON.parse(this.itemInfo)
    this.payForm = this.fb.group({
      productName: [product.productName, [Validators.required, ]],
      category: [product.category, [Validators.required]],
      price: [product.price, [Validators.required]],
      amountPaid: ['', [Validators.required]],
      minDue: ['', [Validators.required]],
      cardDetailId: ['', [Validators.required]],
      isActive:[true]
    })

  }
  get addCardsControl() { return this.payForm.controls; }

  payNow(){
    console.log(this.payForm.value);

    let selectedCard:any;
    selectedCard = this.creditCards.find(item => item.cardDetailId == this.payForm.value.cardDetailId);
    console.log(selectedCard);
    this.payForm.value.cardNumber = selectedCard.cardNumber;
    this.payForm.value.bank = selectedCard.bank;


    let url = environment.baseUrl + "Pay";
        this.cardService.payBill(url,this.payForm.value).subscribe((res)=>{
      console.log(res);
      if(res) {
        this.router.navigate(['/user/paymentDetails']);

      }

    })
  }
  getAllCards() {
    let url = environment.baseUrl + "CardDetails";
    this.cardService.getCard(url).subscribe((res)=>{
      console.log(res);
      if(res) {
        this.creditCards = res;
      }
    })
  }

}
