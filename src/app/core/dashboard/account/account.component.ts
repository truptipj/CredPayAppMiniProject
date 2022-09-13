import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { CardService } from '../../service/card.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

  bankList = ["SBI", "AXIS", "KOTAK"];

  addCardsForm:any= FormGroup;
  public minDate:any;
    constructor(private router: Router, private fb: FormBuilder,
       private cardService: CardService) {
      this.minDate = new Date();
     }

    ngOnInit(): void {
      this.addCardsForm = this.fb.group({
        cardNumber: ['', [Validators.required,Validators.pattern("^((\\+91-?)|0)?[0-9]{16}$")]],
        cardOwnerName: ['', [Validators.required]],
        expirationDate: ['', [Validators.required]],
        cvv: ['', [Validators.required,Validators.pattern("^((\\+91-?)|0)?[0-9]{3}$")]],
        bank: ['', [Validators.required]],
        balace: ['', [Validators.required,Validators.pattern("^(0|[1-9][0-9]*)$")]],
        isActive:[true],

      })
    }
    get addCardsControl() { return this.addCardsForm.controls; }
    addCard(){


     let url = "https://localhost:44352/api/CardDetails";
      this.cardService.addCard(url,this.addCardsForm.value).subscribe((res)=>{
        if(res.result) {
          this.router.navigate(['/user/cards']);
        }
      })
    }
    getToday(): string {
      return new Date().toISOString().split('T')[0]
   }
  }
