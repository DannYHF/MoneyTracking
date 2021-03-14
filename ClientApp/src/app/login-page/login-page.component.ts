import { Component } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {AuthService} from "../services/auth.service";
import {LoginRequest} from "../shared/intefaces";
import {ActivatedRoute, Params, Router} from "@angular/router";

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent {

  loginForm = new FormGroup({
    email: new FormControl(null,[Validators.required,Validators.email]),
    password: new FormControl(null,[Validators.required])
  });
  message:string = '';
  submitted = false;
  constructor(private authService: AuthService,
              private router: Router,
              private route: ActivatedRoute) {
    this.route.queryParams.subscribe((params:Params) =>
    {
      if(params["accessDenied"] === "true"){
        this.message = "You have not authenticated";
      }
    })
  }

  login() {
    this.submitted = true;
    const request:LoginRequest = {
      password: this.loginForm.value.password,
      email: this.loginForm.value.email
    }
    this.authService.login(request).subscribe(() =>{
      this.loginForm.reset();
      this.router.navigate(['']);
      this.submitted = false;
    }, error => {this.submitted = false})
  }
}
