import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

bankList = ["SBI", "AXIS", "KOTAK"]
addCardsForm:any= FormGroup;


  constructor(private router: Router, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.addCardsForm = this.fb.group({
      CardNumber: ['', [Validators.required,Validators.pattern("^((\\+91-?)|0)?[0-9]{16}$")]],
      CardOwnerName: ['', [Validators.required,Validators.pattern('^[a-zA-Z]+$')]],
      ExpirationDate: ['', [Validators.required]],
      cvv: ['', [Validators.required,Validators.pattern("^((\\+91-?)|0)?[0-9]{3}$")]],
      isActive:[true]
    })
  }
  //get addCardsControl() { return this.addCardsForm.controls; }
  addCard(){
    this.router.navigate(['/user/cards']);
  }
  getToday(): string {
    return new Date().toISOString().split('T')[0]
 }
}
