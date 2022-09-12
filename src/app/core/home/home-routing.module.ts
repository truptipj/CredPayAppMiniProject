import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeHeaderComponent } from './home-header/home-header.component';
import {LoginComponent} from './login/login.component'
import { PublicComponent } from './public/public.component';
import { RegisterComponent } from './register/register.component';


const routes: Routes = [

  {
    path:'', component:HomeHeaderComponent,
    children:[
      {
        path:'', redirectTo:'public', pathMatch: 'full',
      },
      {
        path:'public', component: PublicComponent
      },

      {
        path:'login', component: LoginComponent
      },
      {
        path:'register', component: RegisterComponent
      }
    ]
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
