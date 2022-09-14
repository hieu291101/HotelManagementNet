import { Component, OnInit } from '@angular/core';
import { BookingListService } from './booking-list.service';

@Component({
  selector: 'app-booking-list',
  templateUrl: './booking-list.component.html',
  styleUrls: ['./booking-list.component.css']
})
export class BookingListComponent implements OnInit {
  tableHeaders: any;
  tableValue?: any[];
  curPage = 1;
  totalPages?: any;

  constructor(private _bookingList: BookingListService) { }

  ngOnInit(): void {
    this.tableHeaders = this._bookingList.loadTableHeader();

    this._bookingList.getBookings(this.curPage).subscribe();

    this._bookingList.tableValue$.subscribe((res: any) => {
      this.tableValue = res;
    });

    this._bookingList.totalPages$.subscribe((res: any) => {
      this.totalPages = res;
    });
  }

  prev() {
    if (this.curPage === 1) return;
    this.curPage--;
    this._bookingList.getBookings(this.curPage).subscribe();
  }

  next() {
    if (this.curPage === this.totalPages) return;
    this.curPage++;
    this._bookingList.getBookings(this.curPage).subscribe();
  }
}
