import {Component} from '@angular/core';
import {ResizedEvent} from "angular-resize-event";

@Component({
  selector: 'app-dashboard-page',
  templateUrl: './dashboard-page.component.html',
  styleUrls: ['./dashboard-page.component.scss']
})
export class DashboardPageComponent{
  view:[number,number] = [500,300];

  constructor() { }

  onResize(event:ResizedEvent) {
    this.view = [event.newWidth, 300];
  }
}
