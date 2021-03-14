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
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {AngularResizedEventModule} from "angular-resize-event";
import { LoginPageComponent } from './login-page/login-page.component';
import { RegisterPageComponent } from './register-page/register-page.component';
import {JwtModule} from "@auth0/angular-jwt";
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {TokenInterceptor} from "./shared/token-interceptor";
import {ACCESS_TOKEN} from "./shared/local-storage-variables";

export function tokenGetter() {
  return localStorage.getItem(ACCESS_TOKEN);
}

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    DashboardPageComponent,
    CostTablePageComponent,
    CategoriesComponent,
    LastCostsComponent,
    DonutChartComponent,
    LoginPageComponent,
    RegisterPageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgxChartsModule,
    BrowserAnimationsModule,
    AngularResizedEventModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter
      }
    }),
    ReactiveFormsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
