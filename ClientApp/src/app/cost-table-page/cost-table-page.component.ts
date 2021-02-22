import { Component, OnInit } from '@angular/core';
import {Cost} from "../shared/intefaces";

@Component({
  selector: 'app-cost-table-page',
  templateUrl: './cost-table-page.component.html',
  styleUrls: ['./cost-table-page.component.scss']
})
export class CostTablePageComponent implements OnInit {
  costs!:Cost[]

  constructor() { }

  ngOnInit(): void {
    this.costs = [
      {categoryName:'Food', amountOfMoney:10, CreateDate: new Date()},
      {categoryName:'Wear', amountOfMoney:300, CreateDate: new Date()},
      {categoryName:'Food', amountOfMoney:40, CreateDate: new Date()},
      {categoryName:'Cafe', amountOfMoney:50, CreateDate: new Date()}
    ]
  }
}
