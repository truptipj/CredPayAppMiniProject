import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardRoutingModule } from './dashboard-rounting.module';
import {NgxPaginationModule} from 'ngx-pagination';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AccountComponent } from './account/account.component';
import { CardsComponent } from './cards/cards.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LayoutComponent } from './layout/layout.component';
import { PayNowComponent } from './pay-now/pay-now.component';
import { PaymentDetailsComponent } from './payment-details/payment-details.component';
import { MaskPipe } from './Pipes/mask/mask.pipe';
import { ShopComponent } from './shop/shop.component';
import { TransactComponent } from './transact/transact.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';

@NgModule({
  declarations: [
    LayoutComponent,
    DashboardComponent,
    AccountComponent,
    CardsComponent,
    PayNowComponent,
    PaymentDetailsComponent,
    TransactComponent,
    ShopComponent,
    MaskPipe


  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    ReactiveFormsModule,
    NgxPaginationModule,
    FormsModule,
    Ng2SearchPipeModule


  ]
})
export class DashboardModule { }
