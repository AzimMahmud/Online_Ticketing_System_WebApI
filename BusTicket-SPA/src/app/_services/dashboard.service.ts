import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { HttpHeaders } from "@angular/common/http";
import { t } from "@angular/core/src/render3";

@Injectable({
  providedIn: "root"
})
export class DashboardService {
  baseUrl: any;

  constructor(private http: Http) {
    this.baseUrl = window.localStorage.getItem("apikey");
  }

  getAllVendor(): Observable<any> {
    return this.http
      .get(this.baseUrl + "/api/Dashboard/GetTotalVendor")
      .pipe(map(res => res.json()));
  }

  getTotalSales(): Observable<any> {
    return this.http
      .get(this.baseUrl + "/api/Dashboard/GetTotalSales")
      .pipe(map(res => res.json()));
  }
}
