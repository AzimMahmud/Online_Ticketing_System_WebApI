import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { map } from "rxjs/operators";
import { Observable } from "rxjs";
import { IVendorPayment } from "../models/IVendorPayment";

@Injectable({
  providedIn: 'root'
})
export class VendorPaymentService {

  baseUrl: any;

  constructor(private http: Http) {
    this.baseUrl = window.localStorage.getItem("apikey");
  }

  getVendorPayments() {
    return this.http
      .get(this.baseUrl + "/api/VendorPayment")
      .pipe(map(res => res.json()));
  }

  getArchiveVendorPayments() {
    return this.http
      .get(this.baseUrl + "/api/VendorPayment/GetArchive")
      .pipe(map(res => res.json()));
  }

  getVendorPaymentsById(id: number) {
    return this.http
      .get(this.baseUrl + "/api/VendorPayment/" + id)
      .pipe(map(res => res.json()));
  }

  createVendorPayments(formData) {
    return this.http
      .post(this.baseUrl + "/api/VendorPayment", formData)
      .pipe(map(res => res.json()));
  }
  updateVendorPayments(id: number, formData: IVendorPayment) {
    formData.vendorPaymentID = id;
    return this.http
      .put(this.baseUrl + "/api/VendorPayment" , formData)
      .pipe(map(res => res.json()));
  }
  
  softDelete(id: number) {
    return this.http
      .put(this.baseUrl + "/api/VendorPayment/VendorPaymentDelete/" + id, null)
      .pipe(map(res => res.json()));
  }
  deleteVendorPayments(id) {
    return this.http
      .delete(this.baseUrl + "/api/VendorPayment/" + id)
      .pipe(map(res => res.json()));
  }
  getVendorDetailsSelectOption() {
    return this.http
      .get(this.baseUrl + "/api/BusDetail/GetVendorDetails")
      .pipe(map(res => res.json()));
  }
}
