import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { map } from "rxjs/operators";
import { IBusCategory } from "../models/IBusCategory";

@Injectable({
  providedIn: "root"
})
export class BusCategoryService {
  baseUrl: any;

  constructor(private http: Http) {
    this.baseUrl = window.localStorage.getItem("apikey");
  }

  getBusCategory() {
    return this.http
      .get(this.baseUrl + "/api/BusCategory")
      .pipe(map(res => res.json()));
  }

  getArchiveBusCategory() {
    return this.http
      .get(this.baseUrl + "/api/BusCategory/GetArchive")
      .pipe(map(res => res.json()));
  }

  getBusCategoryById(id: number) {
    return this.http
      .get(this.baseUrl + "/api/BusCategory/" + id)
      .pipe(map(res => res.json()));
  }

  createBusCategory(formData: any) {
    return this.http
      .post(this.baseUrl + "/api/BusCategory", formData)
      .pipe(map(res => res.json()));
  }
  updateBusCategory(id: number, formData: IBusCategory) {
    formData.busCategoryId = id;
    return this.http
      .put(this.baseUrl + "/api/BusCategory/" + id, formData)
      .pipe(map(res => res.json()));
  }

  softDelete(busCategoryId: number) {
    return this.http
      .put(this.baseUrl + "/api/BusCategory/BusCategoryDelete/" + busCategoryId, null)
      .pipe(map(res => res.json()));
  }
  deleteBusCategory(id) {
    return this.http
      .delete(this.baseUrl + "/api/BusCategory/" + id)
      .pipe(map(res => res.json()));
  }
}
