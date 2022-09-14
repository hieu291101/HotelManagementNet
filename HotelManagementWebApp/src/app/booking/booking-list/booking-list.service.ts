import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject, map, Observable, tap } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class BookingListService {
    readonly baseUrlApi = "https://localhost:44370/api";

    tableValue = new BehaviorSubject([]);
    totalPages = new BehaviorSubject(undefined);

    get tableValue$() {
        return this.tableValue.asObservable();
    }

    get totalPages$() {
        return this.totalPages.asObservable();
    }
    
    constructor(private _http: HttpClient) { }

    loadTableHeader() {
        return [
            { field: 'bookingId', header: 'Booking ID' },
            { field: 'bookingDate', header: 'Booking Date' },
            { field: 'durationStay', header: 'Duration Stay' },
            { field: 'checkInDate', header: 'Check-in Date' },
            { field: 'checkOutDate', header: 'Check-out Date' },
            { field: 'bookingPaymentType', header: 'Booking Payment Type' },
            { field: 'totalRoomsBooked', header: 'Total Rooms Booked' },
            { field: 'hotelId', header: 'Hotel ID' },
            { field: 'guestId', header: 'Guest ID' },
            { field: 'employeeId', header: 'Employee ID' },
            { field: 'totalAmount', header: 'Total Amount' },
            { field: 'createdDateTime', header: 'Created Date' },
            { field: 'roomId', header: 'Room ID' },
            { field: 'isDeleted', header: '' },
            { field: 'isProcessed', header: '' },
            { field: 'employee', header: 'Employee' },
            { field: 'guest', header: 'Guest' },
            { field: 'hotel', header: 'Hotel' },
            { field: 'room', header: 'Room' },
            { field: 'roomBooked', header: 'Room Booked' },
            { field: 'actions', header: 'Actions' }
        ];
    }

    getBookings(page: number): Observable<any[]> {
        return this._http.get<any>(this.baseUrlApi + '/Bookings', {
            params: {
                PageNumber: page
            }
        }).pipe(
            map((res: any) => {
                return {
                    ...res,
                    data: res.data.map((e: any) => ({ ...e, actions: 'edit' }))
                }
            }),
            tap((res: any) => {
                this.tableValue.next(res.data);
                this.totalPages.next(res.metadata.totalPages);
            })
        );
    }
}