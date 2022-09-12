import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout/layout.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { DashboardRoutingModule } from './dashboard-rounting.module';
import { AccountComponent } from './account/account.component';
import { PayNowComponent } from './pay-now/pay-now.component';
import { PaymentDetailsComponent } from './payment-details/payment-details.component';
import { CardsComponent } from './cards/cards.component';
import { TransactComponent } from './transact/transact.component';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    LayoutComponent,
    DashboardComponent,
    AccountComponent,
    CardsComponent,
    PayNowComponent,
    PaymentDetailsComponent,
    TransactComponent
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    ReactiveFormsModule
  ]
})
export class DashboardModule { }
