import { HttpClientModule } from '@angular/common/http'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { TableModule } from 'primeng/table';

import { AppComponent } from './app.component';
import { HotelmanagementComponent } from './hotelmanagement/hotelmanagement.component';
import { ShowHotelmanagementComponent } from './hotelmanagement/show-hotelmanagement/show-hotelmanagement.component';
import { AddEditHotelmanagementComponent } from './hotelmanagement/add-edit-hotelmanagement/add-edit-hotelmanagement.component';
import { HotelmanagementApiService } from './hotelmanagement-api.service';
import { BookingListComponent } from './booking/booking-list/booking-list.component';
import { BookingDetailComponent } from './booking/booking-detail/booking-detail.component';
import { ButtonModule } from 'primeng/button';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

@NgModule({
  declarations: [
    AppComponent,
    HotelmanagementComponent,
    ShowHotelmanagementComponent,
    AddEditHotelmanagementComponent,
    BookingListComponent,
    BookingDetailComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    TableModule,
    ButtonModule,
    BrowserAnimationsModule
  ],
  providers: [HotelmanagementApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
