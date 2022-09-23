import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CardService } from '../../service/card.service';

@Component({
  selector: 'app-payment-details',
  templateUrl: './payment-details.component.html',
  styleUrls: ['./payment-details.component.css']
})
export class PaymentDetailsComponent implements OnInit {
 paymentDetail: any
  constructor(private cardService: CardService) { }

  ngOnInit(): void {
    debugger;
    let payment:any = (localStorage.getItem('selectetItem'));
    this.paymentDetail = JSON.parse(payment);
    console.log(this.paymentDetail);
  }
}
