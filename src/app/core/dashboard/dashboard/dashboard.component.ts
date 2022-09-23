import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CardService } from '../../service/card.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  allCard: any;
  totalBalance: any = 0;
  totalOutstandingBalance: any = 0;
  transactions: any;
  constructor(private cardService: CardService ) { }

  ngOnInit(): void {
    this.getAllCards();
    this.getPaymentDetail();
  }
  getAllCards() {
    let url = environment.baseUrl + "CardDetails";
    this.cardService.getCard(url).subscribe((res)=>{
      if(res) {
        this.allCard = res;
      this.totalBalance = this.sumOfArrayWithParameter(this.allCard,'balance');

      }
    })
  }
sumOfArrayWithParameter (array:any, parameter:any) {
  let sum = null;
  if (array && array.length > 0 && typeof parameter === 'string') {
    sum = 0;
    for (let e of array) if (e && e.hasOwnProperty(parameter)) sum += e[parameter];
  }
  return sum;
}

getPaymentDetail(){
  let url = environment.baseUrl + "Pay";
  this.cardService.getTransactions(url).subscribe((res)=>{
    if(res) {
      this.transactions =res;
      this.totalOutstandingBalance = this.sumOfArrayWithParameter(this.transactions,'minDue');

    }
  })
}

}
