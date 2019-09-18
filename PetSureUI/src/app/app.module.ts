import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomerListComponent } from './customer/list/customer-list.component';
import { CustomerService } from './customer/customer.service';
import { HttpClientModule } from '@angular/common/http';

import { MatButtonModule, MatListModule } from '@angular/material';

@NgModule({
  declarations: [
    AppComponent,
    CustomerListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MatButtonModule,
    MatListModule
  ],
  exports: [
    MatButtonModule,
    MatListModule
  ],
  providers: [CustomerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
