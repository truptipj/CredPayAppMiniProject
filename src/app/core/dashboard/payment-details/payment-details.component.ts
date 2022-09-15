import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CardService } from '../../service/card.service';

@Component({
  selector: 'app-payment-details',
  templateUrl: './payment-details.component.html',
  styleUrls: ['./payment-details.component.css']
})
export class PaymentDetailsComponent implements OnInit {
  shopCategoryList: any =[]
BankNameList: any =[]
allTransactList: any =[]
  constructor(private cardService: CardService) { }

  ngOnInit(): void {
    this.getPaymentDetail();
  }
  getPaymentDetail(){
    let url = environment.baseUrl + "PaymentDetail";
    this.cardService.getCard(url).subscribe((res)=>{
      if(res) {
        console.log(res);
      }
    })

}
}
