import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Observable } from "rxjs";
import { IRoutesDetails } from "../models/IRoutesDetails";
import { map } from "rxjs/operators";
import { ITicketReservation } from "../models/ITicketReservation";
import { IPayment } from "../models/IPayment";

@Injectable({
  providedIn: "root"
})
export class TicketReservationService {
  baseUrl: any;

  constructor(private http: Http) {
    this.baseUrl = window.localStorage.getItem("apikey");
  }

  getTicketReservations(): Observable<ITicketReservation> {
    return this.http
      .get(this.baseUrl + "/api/TicketReservation")
      .pipe(map(res => res.json()));
  }
  getgetTicketReservationByCustomer(id): Observable<ITicketReservation> {
    return this.http
      .get(this.baseUrl + "/api/TicketReservation/" + id)
      .pipe(map(res => res.json()));
  }

  postTicketReservation(formData: ITicketReservation) {
    console.log(formData);
    return this.http
      .post(this.baseUrl + "/api/TicketReservation/TicketPurchase", formData)
      .pipe(map(res => res.json()));
  }
  updateTicketReservation(formData) {
    return this.http
      .put(this.baseUrl + "/api/TicketReservation", formData)
      .pipe(map(res => res.json()));
  }
  confirmPayment(payment: IPayment) {
    // payment.status = true;
    console.log(payment);
    return this.http
      .put(this.baseUrl + "/api/TicketReservation/PaymentConfirm", payment)
      .pipe(map(res => res.json()));
  }
}
