import { HttpClientModule} from '@angular/common/http'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HotelmanagementComponent } from './hotelmanagement/hotelmanagement.component';
import { ShowHotelmanagementComponent } from './hotelmanagement/show-hotelmanagement/show-hotelmanagement.component';
import { AddEditHotelmanagementComponent } from './hotelmanagement/add-edit-hotelmanagement/add-edit-hotelmanagement.component';
import { HotelmanagementApiService } from './hotelmanagement-api.service';
@NgModule({
  declarations: [
    AppComponent,
    HotelmanagementComponent,
    ShowHotelmanagementComponent,
    AddEditHotelmanagementComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [HotelmanagementApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
