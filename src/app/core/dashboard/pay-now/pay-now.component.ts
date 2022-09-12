import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CardService } from '../../service/card.service';

@Component({
  selector: 'app-pay-now',
  templateUrl: './pay-now.component.html',
  styleUrls: ['./pay-now.component.css']
})
export class PayNowComponent implements OnInit {
  bankList = ["SBI", "AXIS", "KOTAK"]
  shopCategoryList = ["Shopping", "Travelling", "Food", "Other"]
  allCards= [
    {
      CardNumber:'8778787908756456',
      CardOwnerName:'Mahesh Jain',
      ExpirationDate: '12/5/2023',
      cvv: '123',
      BankName: 'SBI'
    },
    {
      CardNumber:'9898787908756456',
      CardOwnerName:'Jorge Bush',
      ExpirationDate: '1/9/2024',
      cvv: '124',
      BankName: 'AXIS'
    }

  ]
  itemInfo:any;
  payForm:any= FormGroup;
  constructor(private router: Router,private fb: FormBuilder, private cardService: CardService) { }

  ngOnInit(): void {
    this.itemInfo = (localStorage.getItem('selectetItem'));
    console.log(this.itemInfo.name);
    this.getAllCards();
    let product = JSON.parse(this.itemInfo)
    this.payForm = this.fb.group({
      name: [product.name, [Validators.required]],
      category: [product.category, [Validators.required]],
      prise: [product.prise, [Validators.required]],
      creditCard: ['', [Validators.required]],
      isActive:[true]
    })
  }
  get addCardsControl() { return this.payForm.controls;
  }
  payNow(){
    console.log(this.payForm.value);
    // let url = "AddCard";
    //     this.cardService.payBill(url,this.payForm.value).subscribe((res)=>{
    //   console.log(res);
    //   if(res.token) {
    //    this.router.navigate(['user']);
    //   }
    // })
    this.router.navigate(['/user/paymentDetails']);
  }
  getAllCards() {
    // this.cardService.getCard().subscribe((res) => {
    //   this.allCards = res.data;
    // })
  }
}
