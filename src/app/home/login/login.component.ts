import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginService } from '../../core/service/login.service';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/core/service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  constructor(
    private loginService: LoginService,
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private router: Router,
  ) {}

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      UserName: ['', Validators.required],
      Password: ['', [Validators.required]],
    });
  }

  logIn() {
    this.loginService
      .loginPostData(this.loginForm.value)
      .subscribe((res) => {
        if (res.token) {
          this.authService.setToken(res.token);

          this.router.navigate(['user']);
        }
      });
  }

  goToRegister() {
    this.router.navigate(['register']);
  }
}
