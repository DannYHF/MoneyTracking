import { Component, OnInit } from '@angular/core';
import {LastCostsItem} from "../../../shared/intefaces";

@Component({
  selector: 'app-last-costs',
  templateUrl: './last-costs.component.html',
  styleUrls: ['./last-costs.component.scss']
})
export class LastCostsComponent{
  data!:LastCostsItem[];
  constructor() {
    this.data = [
      {categoryName:"Food", amount:10},
      {categoryName:"Wear", amount:300},
      {categoryName:"Food", amount:40},
      {categoryName:"Cafe", amount:50},
    ]
  }

}
