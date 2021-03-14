import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {JwtHelperService} from "@auth0/angular-jwt";
import {Router} from "@angular/router";
import {Observable} from "rxjs";
import {AuthorizationResponse, LoginRequest, RegisterRequest} from "../shared/intefaces";
import {tap} from "rxjs/operators";
import {environment} from "../../environments/environment";
import {ACCESS_TOKEN} from "../shared/local-storage-variables";


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient,
              private jwtService: JwtHelperService,
              private router: Router) {

  }

  login(request:LoginRequest) : Observable<AuthorizationResponse>{
    return this.http.post<AuthorizationResponse>(`${environment.authApi}api/Auth/login`, request)
      .pipe(
      tap(
        response =>localStorage.setItem(ACCESS_TOKEN, response.token)
      )
    )
  }
  isAuthenticated(): boolean{
    const token = localStorage.getItem(ACCESS_TOKEN);
    if(token == null)
      return false;

    return !this.jwtService.isTokenExpired(token);
  }

  logout(){
    localStorage.removeItem(ACCESS_TOKEN);
    this.router.navigate(['/login']);
  }
  register(request:RegisterRequest) : Observable<AuthorizationResponse>{
    return this.http.post<AuthorizationResponse>(`${environment.authApi}api/Auth/register`, request)
      .pipe(
        tap(
          response => localStorage.setItem(ACCESS_TOKEN, response.token)
        )
      )
  }
}
