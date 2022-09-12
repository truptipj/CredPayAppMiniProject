import { Component, OnInit } from '@angular/core';
import { CardService } from '../../service/card.service';

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./cards.component.css']
})
export class CardsComponent implements OnInit {

  allCards= [
    {
      'CardNumber':'8778787908756456',
      'CardOwnerName':'Mahesh Jain',
      'ExpirationDate': '12/5/2023',
      'cvv': '123',
      'BankName': 'SBI'
    },
    {
      'CardNumber':'9898787908756456',
      'CardOwnerName':'Jorge Bush',
      'ExpirationDate': '1/9/2024',
      'cvv': '124',
      'BankName': 'AXIS'
    }

  ]

  constructor(private cardService: CardService) { }

  ngOnInit(): void {
    this.getAllCards();
  }
  getAllCards() {
    // this.cardService.getCard().subscribe((res) => {
    //   this.allCards = res.data;
    // })
  }
}
