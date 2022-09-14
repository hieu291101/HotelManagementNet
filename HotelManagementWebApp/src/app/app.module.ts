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
<<<<<<< HEAD
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { LayoutModule } from './layout/layout.module';
import {MatSidenavModule} from '@angular/material/sidenav';
=======
import { BookingListComponent } from './booking/booking-list/booking-list.component';
import { BookingDetailComponent } from './booking/booking-detail/booking-detail.component';
import { ButtonModule } from 'primeng/button';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

>>>>>>> e9f43249def499dc456128b696a635fab7c49ab1
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
    LayoutModule,
    MatSidenavModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
<<<<<<< HEAD
=======
    TableModule,
    ButtonModule,
>>>>>>> e9f43249def499dc456128b696a635fab7c49ab1
    BrowserAnimationsModule
  ],
  providers: [HotelmanagementApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
