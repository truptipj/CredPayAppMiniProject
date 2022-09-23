import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CardService } from '../../service/card.service';
import { CardInfo } from '../CardInfo';


@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./cards.component.css']
})
export class CardsComponent implements OnInit {

  allCards: CardInfo[] = [];
  p: number = 1;
  filterTerm!: string;
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
  editCard(card:any){
    localStorage.setItem('editCardInfo', JSON.stringify(card))
  }
  deleteCard(card:any){
    let url = environment.baseUrl + "CardDetails?id=" + card.cardDetailId;
    this.cardService.deleteCard(url).subscribe((res)=>{
      if(res) {
        this.getAllCards();
      }
    })
  }
}
