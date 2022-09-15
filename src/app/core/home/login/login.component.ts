import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { LoginService } from '../../service/login.service';
import { AuthService } from '../../service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm !: FormGroup;
  constructor(private loginService: LoginService, private authService: AuthService,private formBuilder: FormBuilder, private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({

      UserName: ['', Validators.required],
      Password: ['', [Validators.required]]

    })
  }


  logIn(){
    //this.router.navigate(['user']);

    let url = environment.baseUrl + "Authenticate/login";
    this.loginService.loginPostData(url,this.loginForm.value).subscribe((res)=>{
      console.log(res);
      if(res.token) {
      this.authService.setToken(res.token);
    this.router.navigate(['user']);

      }
    })
  }
  goToRegister(){

    this.router.navigate(['register'])
  }
}

