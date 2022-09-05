import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { HotelmanagementApiService } from 'src/app/hotelmanagement-api.service';

@Component({
  selector: 'app-show-hotelmanagement',
  templateUrl: './show-hotelmanagement.component.html',
  styleUrls: ['./show-hotelmanagement.component.css']
})
export class ShowHotelmanagementComponent implements OnInit {

  hotels$!:Observable<any[]>;
  bookings$!:Observable<any[]>;
  hotels = []
  constructor(private service:HotelmanagementApiService) { }

  ngOnInit(): void {
    this.hotels$ = this.service.getHotels();
  }

}
