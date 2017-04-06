import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from "@angular/router";

import { NgbPaginationModule } from "@ng-bootstrap/ng-bootstrap";

import { AppComponent } from './app.component';
import { ExpirationReportComponent } from './expiration-report/expiration-report.component';

@NgModule({
  declarations: [
    AppComponent,
    ExpirationReportComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    NgbPaginationModule.forRoot(),
    RouterModule.forRoot([
      {
        path: '',
        redirectTo: 'expiration-report',
        pathMatch: 'full'
      },
      {
        path: 'expiration-report',
        component: ExpirationReportComponent
      }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
