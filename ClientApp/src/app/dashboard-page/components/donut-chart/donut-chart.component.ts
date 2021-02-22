import {Component, Input, OnInit} from '@angular/core';
import {DonutChartCategory} from "../../../shared/intefaces";

@Component({
  selector: 'app-donut-chart',
  templateUrl: './donut-chart.component.html',
  styleUrls: ['./donut-chart.component.scss']
})
export class DonutChartComponent{

  charData!: DonutChartCategory[];
  @Input()
  view:[number,number] = [500, 400];

  // options
  gradient: boolean = true;
  showLegend: boolean = true;
  showLabels: boolean = true;
  isDoughnut: boolean = false;

  colorScheme = {
    domain: ['#5AA454', '#A10A28', '#C7232C']
  };

  constructor() {this.charData = [
      {"name": "Food","value": 50},
      {"name": "Wear","value": 300},
      {"name": "Cafe", "value": 50}
    ];
  }
}
