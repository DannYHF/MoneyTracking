import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {DashboardPageComponent} from "./dashboard-page/dashboard-page.component";
import {CostTablePageComponent} from "./cost-table-page/cost-table-page.component";
import {LoginPageComponent} from "./login-page/login-page.component";
import {RegisterPageComponent} from "./register-page/register-page.component";
import {AuthGuard} from "./shared/auth.guard";

const routes: Routes = [
  {path: '', canActivate:[AuthGuard] , component:DashboardPageComponent},
  {path: 'cost-table', canActivate:[AuthGuard] ,component:CostTablePageComponent},
  {path: 'login', component: LoginPageComponent},
  {path: 'register', component: RegisterPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
