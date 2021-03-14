import { Component, OnInit } from '@angular/core';
import {Cost, Transaction} from "../shared/intefaces";
import {TransactionsService} from "../services/transactions.service";

@Component({
  selector: 'app-cost-table-page',
  templateUrl: './cost-table-page.component.html',
  styleUrls: ['./cost-table-page.component.scss']
})
export class CostTablePageComponent implements OnInit {
  transactions!:Transaction[]

  constructor(private service:TransactionsService) { }

  ngOnInit(): void {
    this.service.getTransactions().subscribe((transactions)=>{
      this.transactions= transactions;
    });
  }
}
