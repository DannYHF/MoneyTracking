import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import {Observable} from "rxjs";
import {ACCESS_TOKEN} from "./local-storage-variables";
import {AuthService} from "../services/auth.service";

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    if(this.authService.isAuthenticated()){
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${localStorage.getItem(ACCESS_TOKEN)}`
        }
      });
    }
    return next.handle(request);
  }
}
