import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterService } from 'src/app/core/service/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;;

  constructor(
    private registerService: RegisterService,
    private fb: FormBuilder,
    private router: Router,
  ) {}

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      UserName: ['', Validators.required],
      Email: ['', [Validators.required, Validators.email]],
      FullName: ['', Validators.required],
      Password: ['', [Validators.required]],
    });
  }

  public onSubmit(): void {
    this.registerService
      .registerPostData(this.registerForm.value)
      .subscribe((res) => {
        this.router.navigate(['login']);
      });
  }

  openLogin() {
    this.router.navigate(['login']);
  }
}
