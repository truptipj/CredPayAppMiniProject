import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeRoutingModule } from './home-routing.module';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { PublicComponent } from './public/public.component';
import { HomeHeaderComponent } from './home-header/home-header.component';


@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    PublicComponent,
    HomeHeaderComponent

  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    RouterModule,
    ReactiveFormsModule

  ]
})
export class HomeModule { }
