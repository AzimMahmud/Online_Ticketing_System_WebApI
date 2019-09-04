import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { IBusDetails } from "../models/IBusDetails";

@Injectable({
  providedIn: "root"
})
export class BusDetailsService {
  baseUrl: any;

  constructor(private http: Http) {
    this.baseUrl = window.localStorage.getItem("apikey");
  }

  getBusDetails(): Observable<any> {
    return this.http
      .get(this.baseUrl + "/api/BusDetail/GetBusInfo")
      .pipe(map(res => res.json()));
  }
  getArchiveBusDetails(): Observable<any> {
    return this.http
      .get(this.baseUrl + "/api/BusDetail/GetArchive")
      .pipe(map(res => res.json()));
  }

  getVendorDetailsSelectOption() {
    return this.http
      .get(this.baseUrl + "/api/BusDetail/GetVendorDetails")
      .pipe(map(res => res.json()));
  }

  getCategoryDetailsSelectOption(): Observable<any[]> {
    return this.http
      .get(this.baseUrl + "/api/BusDetail/GetCategoryDetails")
      .pipe(map(res => res.json()));
  }

  getBrandDetailsSelectOption(): Observable<any[]> {
    return this.http
      .get(this.baseUrl + "/api/BusDetail/GetBrandDetails")
      .pipe(map(res => res.json()));
  }

  getBusDetailById(id): Observable<IBusDetails> {
    return this.http
      .get(this.baseUrl + "/api/BusDetail/" + id)
      .pipe(map(res => res.json()));
  }

  createBusDetail(formData: IBusDetails) {
    return this.http
      .post(this.baseUrl + "/api/BusDetail", formData)
      .pipe(map(res => res.json()));
  }
  updateBusDetail(id: number, formData: IBusDetails) {
    formData.busDetailID = id;
    return this.http
      .put(this.baseUrl + "/api/BusDetail", formData)
      .pipe(map(res => res.json()));
  }

  softDelete(id: number) {
    return this.http
      .put(this.baseUrl + "/api/BusDetail/BusDetailDelete/" + id, null)
      .pipe(map(res => res.json()));
  }

  deleteBusDetail(id) {
    return this.http
      .delete(this.baseUrl + "/api/BusDetail/" + id)
      .pipe(map(res => res.json()));
  }
}
