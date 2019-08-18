import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs';
import { IRoutesDetails } from '../models/IRoutesDetails';
import { map } from 'rxjs/operators';
import { ITicketReservation } from '../models/ITicketReservation';

@Injectable({
  providedIn: 'root'
})
export class TicketReservationService {

  baseUrl: any;

  constructor(private http: Http) {
    this.baseUrl = window.localStorage.getItem("apikey");
  }

  getTicketReservations(): Observable<ITicketReservation> {
    return this.http
      .get(this.baseUrl + "/api/ticketreservation")
      .pipe(map(res => res.json()));
  }
  getgetTicketReservationByCustomer(id): Observable<ITicketReservation> {
    return this.http
      .get(this.baseUrl + "/api/Ticketreservation/" + id)
      .pipe(map(res => res.json()));
  }

  postTicketReservation(formData) {
    return this.http
      .post(this.baseUrl + "/api/Ticketreservation", formData)
      .pipe(map(res => res.json()));
  }
  updateTicketReservation(formData) {
    return this.http
      .put(this.baseUrl + "/api/Ticketreservation", formData)
      .pipe(map(res => res.json()));
  }
  deleteTicketReservation(id) {
    return this.http
      .delete(this.baseUrl + "/api/Ticketreservation/" + id)
      .pipe(map(res => res.json()));
  }

}
