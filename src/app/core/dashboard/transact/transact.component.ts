import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { CardService } from '../../service/card.service';

@Component({
  selector: 'app-transact',
  templateUrl: './transact.component.html',
  styleUrls: ['./transact.component.css']
})
export class TransactComponent implements OnInit {

  transactions: any = [];
  cards:any = [];
  p: number = 1;
  constructor(private cardService: CardService, private router: Router) { }

  ngOnInit(): void {
    this.getAllCards();
  }
  getPaymentDetail(){
    let url = environment.baseUrl + "Pay";
    this.cardService.getTransactions(url).subscribe((res)=>{
      if(res) {
        this.transactions = res;
        this.manageTransactions();

      }
    })
}
getAllCards() {
  let url = environment.baseUrl + "CardDetails";
  this.cardService.getCard(url).subscribe((res)=>{
    if(res) {
      this.cards = res;
      this.getPaymentDetail();
    }
  })
}

manageTransactions(){
  console.log('called');
  if((this.cards.length > 0) && (this.transactions.length > 0)) {
    this.transactions.forEach((element:any) => {
      console.log(element);
      console.log(this.cards);

      let card:any;
      card = this.cards.find((x:any) => {
        if(x.cardDetailId == element.cardDetailId) {
          return x.cardDetailId == element.cardDetailId
        } else {
          return null
        }
      });

      console.log(card);
      element.cardNumber = (card && card.cardNumber)?card.cardNumber: '';
      element.bank = (card && card.bank)?card.bank: '';
      element.cardOwnerName = (card && card.cardOwnerName)?card.cardOwnerName: '';
      element.balance = (card && card.balance)?card.balance: '';

    });
    console.log(this.transactions);
  }
}
view(item: any, isUpdate:boolean){
  console.log(item);

      let selectetItem = JSON.stringify({
      productName: item.productName,
      category: item.category,
      minDue: item.minDue,
      cardDetailId: item.cardDetailId,
      balance: item.balance,
      price: item.price,
      // Date: item.date,  /*added*/


      amountPaid: item.amountPaid,
      bank: item.bank,
      cardNumber: item.cardNumber,
      cardOwnerName: item.cardOwnerName,
      payId: item.payId,
      status: item.status,
      userId: item.userId,
    });
    localStorage.setItem('selectetItem', selectetItem)
    if(isUpdate) {
      this.router.navigate(['/user/paynow']);
    }
}
}

