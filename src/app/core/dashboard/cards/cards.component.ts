import { Component, OnInit } from '@angular/core';
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
}

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./cards.component.css']
})
export class CardsComponent implements OnInit {

  allCards: CardInfo[] = [];
  // allCards= [
  //   {
  //     'CardNumber':'8778787908756456',
  //     'CardOwnerName':'Mahesh Jain',
  //     'ExpirationDate': '12/5/2023',
  //     'cvv': '123',
  //     'BankName': 'SBI'
  //   },
  //   {
  //     'CardNumber':'9898787908756456',
  //     'CardOwnerName':'Jorge Bush',
  //     'ExpirationDate': '1/9/2024',
  //     'cvv': '124',
  //     'BankName': 'AXIS'
  //   }

  // ]

  constructor(private cardService: CardService) { }

  ngOnInit(): void {
    this.getAllCards();
  }
  getAllCards() {
    let url = environment.baseUrl + "CardDetails";
    this.cardService.getCard(url).subscribe((res)=>{
      if(res) {
        this.allCards = res;
      }
    })
  }
}
