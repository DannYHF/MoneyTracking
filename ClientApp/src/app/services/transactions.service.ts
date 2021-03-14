import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Transaction} from "../shared/intefaces";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class TransactionsService {
  constructor(private http:HttpClient) {
  }

  getTransactions(): Observable<Transaction[]>{
    return this.http.get<Transaction[]>(`${environment.MTApi}api/Transactions`)
  }
}
