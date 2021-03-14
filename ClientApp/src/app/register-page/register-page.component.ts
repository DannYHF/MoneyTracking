import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { AuthService } from "../services/auth.service";
import { Router } from "@angular/router";
import { RegisterRequest } from "../shared/intefaces";

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.scss']
})
export class RegisterPageComponent{

  registerForm = new FormGroup({
    email: new FormControl(null,[
      Validators.required,
      Validators.email]),
    password: new FormControl(null,[
      Validators.required,
      Validators.minLength(6)]),
    confirmPassword: new FormControl(null,[
      Validators.required,
      Validators.minLength(6)
    ]),
    firstName: new FormControl(null,[
      Validators.required
    ]),
    lastName: new FormControl(null,[
      Validators.required
    ])
  });
  message:string = '';
  submitted = false;

  constructor(private authService: AuthService,
              private router: Router) {
  }

  register() {
    this.submitted = true;
    if(this.registerForm.value.confirmPassword !== this.registerForm.value.password){
      this.message += "Password mismatch.\n";
      this.submitted = false;
      return
    }
    const request:RegisterRequest = {
      password: this.registerForm.value.password,
      email: this.registerForm.value.email,
      confirmPassword:  this.registerForm.value.confirmPassword,
      lastName:  this.registerForm.value.lastName,
      firstName:  this.registerForm.value.firstName
    };
    this.authService.register(request).subscribe(() =>{
      this.registerForm.reset();
      this.router.navigate(['']);
      this.submitted = false;
    }, error => {this.submitted = false})
  }
}

