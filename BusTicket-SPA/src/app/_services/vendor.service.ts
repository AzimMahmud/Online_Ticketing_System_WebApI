import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { map } from "rxjs/operators";
import { Observable } from "rxjs";
import { IVendor } from "../models/IVendor";

@Injectable({
  providedIn: "root"
})
export class VendorService {
  baseUrl: any;

  constructor(private http: Http) {
    this.baseUrl = window.localStorage.getItem("apikey");
  }

  getVendors(): Observable<IVendor[]> {
    return this.http
      .get(this.baseUrl + "/api/Vendor")
      .pipe(map(res => res.json()));
  }

  getArchiveVendors(): Observable<IVendor[]> {
    return this.http
      .get(this.baseUrl + "/api/Vendor/GetArchive")
      .pipe(map(res => res.json()));
  }

  getVendorById(id) : Observable<IVendor> {
    return this.http
      .get(this.baseUrl + "/api/Vendor/" + id)
      .pipe(map(res => res.json()));
  }

  createVendor(formData) {
    return this.http
      .post(this.baseUrl + "/api/Vendor", formData)
      .pipe(map(res => res.json()));
  }
  updateVendor(id : number, formData: IVendor) {
    formData.vendorID = id;
    return this.http
      .put(this.baseUrl + "/api/Vendor", formData)
      .pipe(map(res => res.json()));
  }

  softDelete(vendorID: number) {
    return this.http
      .put(this.baseUrl + "/api/Vendor/VendorDelete/" + vendorID, null)
      .pipe(map(res => res.json()));
  }

  deleteVendor(id) {
    return this.http
      .delete(this.baseUrl + "/api/Vendor/" + id)
      .pipe(map(res => res.json()));
  }
}
