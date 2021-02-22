import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {DashboardPageComponent} from "./dashboard-page/dashboard-page.component";
import {CostTablePageComponent} from "./cost-table-page/cost-table-page.component";

const routes: Routes = [
  {path: '', component:DashboardPageComponent},
  {path: 'cost-table', component:CostTablePageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
