import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { CardService } from '../../service/card.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit, OnDestroy {

  bankList = ["SBI", "AXIS", "KOTAK"];

  addCardsForm:any= FormGroup;
  public minDate:any;
  editCreditCard: any;
  isUpdate = false;
  title = 'Add';

    constructor(private router: Router, private fb: FormBuilder,
       private cardService: CardService) {
      this.minDate = new Date();
     }

    ngOnInit(): void {
      let editCreditCard:any = (localStorage.getItem('editCardInfo'));
      this.editCreditCard = JSON.parse(editCreditCard)



      this.addCardsForm = this.fb.group({
        cardNumber: [(this.editCreditCard && this.editCreditCard.cardNumber) || '', [Validators.required,Validators.pattern("^((\\+91-?)|0)?[0-9]{16}$")]],
        cardOwnerName: [(this.editCreditCard && this.editCreditCard.cardOwnerName) || '', [Validators.required]],
        expirationDate: [(this.editCreditCard && this.editCreditCard.expirationDate) || '', [Validators.required]],
        cvv: [(this.editCreditCard && this.editCreditCard.cvv) || '', [Validators.required,Validators.pattern("^((\\+91-?)|0)?[0-9]{3}$")]],
        bank: [(this.editCreditCard && this.editCreditCard.bank) || '', [Validators.required]],
        balance: [(this.editCreditCard && this.editCreditCard.balance) || '', [Validators.required,Validators.pattern("^(0|[1-9][0-9]*)$")]],
        isActive:[true],

      })

      if(this.editCreditCard){
        this.isUpdate = true;
        this.title = 'Update';
      }

    }





    get addCardsControl() { return this.addCardsForm.controls; }


    addUpdateCard(){
      if(!this.isUpdate) {
        let url = environment.baseUrl + "CardDetails";
        this.cardService.addCard(url,this.addCardsForm.value).subscribe((res)=>{
          if(res.result) {
            this.router.navigate(['/user/cards']);
          }
        })
      } else {

        let reqobj = this.addCardsForm.value;
        reqobj.cardDetailId = this.editCreditCard.cardDetailId;
        let url = environment.baseUrl + "CardDetails?id=" + this.editCreditCard.cardDetailId;
         this.cardService.updateCard(url,reqobj).subscribe((res)=>{
           if(res) {
             this.router.navigate(['/user/cards']);
           }
         })
         localStorage.removeItem('editCardInfo');
         this.editCreditCard = null;
      }

    }
    getToday(): string {
      return new Date().toISOString().split('T')[0]
   }


   ngOnDestroy() {

    localStorage.removeItem('editCardInfo');
    this.editCreditCard = null;
    this.isUpdate = false
  }
  }
