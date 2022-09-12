import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { RegisterService } from '../../service/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: any;

  constructor(private registerService: RegisterService, private fb:FormBuilder, private router:Router,) { }

  ngOnInit(): void {
      this.registerForm = this.fb.group({
        UserName: ['', Validators.required],
        Email: ['', [Validators.required, Validators.email]],
        FullName: ['', Validators.required],
      Password: [  '', [
        Validators.required
       // Validators.pattern('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}')
       ]  ],
       },);
  }
  public onSubmit(): void {
    console.log(this.registerForm.value);
    let url = environment.baseUrl + "Register";
    this.registerService.registerPostData(url,this.registerForm.value).subscribe((res)=>{
      alert("user created successfully!")
      this.router.navigate(['login'])
    })

    localStorage.setItem('form-data', JSON.stringify(this.registerForm.value));
}
openLogin(){
  this.router.navigate(['login'])
}
}






















//   register ! : FormGroup;
//   constructor(private registerService: RegisterService,private formBuilder:FormBuilder,private http:HttpClient,private router:Router) { }

//   ngOnInit(): void {
//     this.register = this.formBuilder.group({
//       // FullName:[''],
//       // Email:[''],
//       // UserName:[''],
//       //   Password:[''],
//       UserName: ['', Validators.required],
//       Email: ['', [Validators.required, Validators.email]],
//       FullName: ['', Validators.required],
//     Password: [  '', [
//       Validators.required
//      // Validators.pattern('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}')
//      ]  ],


//     })
//   }
//   //make method to create user

//   // registerForm(){
//   //     this.http.post<any>('https://localhost:44341/api/Authenticate/register',this.register.value).subscribe(res=>{
//   //       alert("Registration Successful");
//   //       this.register.reset();
//   //       this.router.navigate(['login'])
//   //     })

//       public registerForm(): void {
//         console.log(this.register.value);
//         let url = environment.baseUrl + "Register";
//         this.registerService.registerPostData(url,this.register.value).subscribe((res)=>{
//           if(res.result) {
//             this.router.navigate(['login'])
//           }
//         })

//         localStorage.setItem('form-data', JSON.stringify(this.register.value));
//     }
//     openLogin(){
//       this.router.navigate(['login'])
//     }
//     }
//  // }

// //}
