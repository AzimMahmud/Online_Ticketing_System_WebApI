import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { map } from "rxjs/operators";
import { Observable } from "rxjs";

import { IPromoOffer } from "../models/IPromoOffer";

@Injectable({
  providedIn: "root"
})
export class PromoService {
  baseUrl: any;

  constructor(private http: Http) {
    this.baseUrl = window.localStorage.getItem("apikey");
  }

  getPromo(): Observable<IPromoOffer> {
    return this.http
      .get(this.baseUrl + "/api/PromoOffer")
      .pipe(map(res => res.json()));
  }
  getPromoById(id): Observable<IPromoOffer> {
    return this.http
      .get(this.baseUrl + "/api/PromoOffer/" + id)
      .pipe(map(res => res.json()));
  }

  createPromo(formData) {
    return this.http
      .post(this.baseUrl + "/api/PromoOffer", formData)
      .pipe(map(res => res.json()));
  }
  updatePromo(formData) {
    return this.http
      .put(this.baseUrl + "/api/PromoOffer", formData)
      .pipe(map(res => res.json()));
  }
  deletePromo(id) {
    return this.http
      .delete(this.baseUrl + "/api/PromoOffer/" + id)
      .pipe(map(res => res.json()));
  }
}
