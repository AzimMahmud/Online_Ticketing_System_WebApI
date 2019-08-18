import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Observable } from "rxjs";
import { map } from "rxjs/internal/operators/map";
import { IRoutesDetails } from "../models/IRoutesDetails";
import { IRouteAvailabilityDetails } from "../models/IRouteAvailabilityDetails";

@Injectable({
  providedIn: "root"
})
export class RouteService {
  baseUrl: any;

  constructor(private http: Http) {
    this.baseUrl = window.localStorage.getItem("apikey");
  }

  getRoutes(
    bPont: string,
    dPoint: string,
    jDate: string
  ): Observable<IRouteAvailabilityDetails> {
    return this.http
      .get(
        this.baseUrl +
          "/api/Route/RouteDetails?bPoint=" +
          bPont +
          "&dPoint=" +
          dPoint +
          "&jDate=" +
          jDate 
      )
      .pipe(map(res => res.json()));
  }
  getRoutesById(id): Observable<IRoutesDetails> {
    return this.http
      .get(this.baseUrl + "/api/Route/" + id)
      .pipe(map(res => res.json()));
  }

  createRoute(formData) {
    return this.http
      .post(this.baseUrl + "/api/Route", formData)
      .pipe(map(res => res.json()));
  }
  updateRoute(formData) {
    return this.http
      .put(this.baseUrl + "/api/Route", formData)
      .pipe(map(res => res.json()));
  }
  deleteRoute(id) {
    return this.http
      .delete(this.baseUrl + "/api/Route/" + id)
      .pipe(map(res => res.json()));
  }
}
