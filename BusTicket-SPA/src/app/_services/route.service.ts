import { Injectable, EventEmitter } from "@angular/core";
import { Http } from "@angular/http";
import { Observable } from "rxjs";
import { map } from "rxjs/internal/operators/map";
import { IRoutesDetails } from "../models/IRoutesDetails";
import { IRouteAvailabilityDetails } from "../models/IRouteAvailabilityDetails";
import { IBusRoute } from "../models/IBusRoute";

@Injectable({
  providedIn: "root"
})
export class RouteService {
  baseUrl: any;
  $isSeatBooked = new EventEmitter();
  // routeDetails: any = {
  //   routeID: "",
  //   boardPoint: "",
  //   boardTime: "",
  //   dropPoint: "",
  //   dropTime: "",
  //   busDetailID: "",
  //   fare: "",
  //   IsActive: ""
  // };
  $selectedBusDetails: SelectedBusDetails = {
    routeID: 0,
    seates: []
  };

  constructor(private http: Http) {
    this.baseUrl = window.localStorage.getItem("apikey");
  }

  getSelectedSeatDetails(routeid, seats) {
    this.$selectedBusDetails.routeID = routeid;
    this.$selectedBusDetails.seates = seats;
    this.$isSeatBooked.emit(this.$selectedBusDetails);
  }

  getRoutesForTicketReservation(
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

  getRoutes(): Observable<any[]> {
    return this.http
      .get(this.baseUrl + "/api/Route")
      .pipe(map(res => res.json()));
  }

  getArchiveData(): Observable<any[]> {
    return this.http
      .get(this.baseUrl + "/api/Route/GetArchiveRoute")
      .pipe(map(res => res.json()));
  }

  getBusDetails(): Observable<any[]> {
    return this.http
      .get(this.baseUrl + "/api/BusDetail/getbusinfo")
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

export class SelectedBusDetails {
  routeID: any;
  seates: any[];
}
