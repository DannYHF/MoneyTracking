import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { DashboardPageComponent } from './dashboard-page/dashboard-page.component';
import { CostTablePageComponent } from './cost-table-page/cost-table-page.component';
import { CategoriesComponent } from './dashboard-page/components/categories/categories.component';
import { LastCostsComponent } from './dashboard-page/components/last-costs/last-costs.component';
import { DonutChartComponent } from './dashboard-page/components/donut-chart/donut-chart.component';
import {NgxChartsModule} from "@swimlane/ngx-charts";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {FormsModule} from "@angular/forms";
import {AngularResizedEventModule} from "angular-resize-event";

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    DashboardPageComponent,
    CostTablePageComponent,
    CategoriesComponent,
    LastCostsComponent,
    DonutChartComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgxChartsModule,
    BrowserAnimationsModule,
    AngularResizedEventModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
