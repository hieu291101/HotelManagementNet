import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HotelmanagementApiService {

  readonly  baseUrlApi = "https://localhost:44370/api";

  constructor(private http:HttpClient) { }

  getHotels():Observable<any[]> {
    return this.http.get<any>(this.baseUrlApi + '/Hotels');
  }

  addHotel(data:any) {
    return this.http.post(this.baseUrlApi + '/Hotels', data);
  }

  updateHotel(id:number|string, data:any) {
    return this.http.put(this.baseUrlApi + `/Hotels/${id}`, data);
  }

  deleteHotel(id:number|string) {
    return this.http.delete(this.baseUrlApi + `/Hotels/${id}`);
  }
 }
