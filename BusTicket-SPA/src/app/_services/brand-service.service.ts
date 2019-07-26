import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { map } from "rxjs/operators";

@Injectable({
  providedIn: "root"
})
export class BrandService {
  baseUrl: any;

  constructor(private http: Http) {
    this.baseUrl = window.localStorage.getItem("apikey");
  }

  getBrands() {
    return this.http
      .get(this.baseUrl + "/api/Brand")
      .pipe(map(res => res.json()));
  }
  getBrandById(id) {
    this.http
      .get(this.baseUrl + "/api/Brand/" + id)
      .pipe(map(res => res.json()));
  }

  createBrand(formData) {
    this.http
      .post(this.baseUrl + "/api/Brand", formData)
      .pipe(map(res => res.json()));
  }
  updateBrand(formData) {
    this.http
      .put(this.baseUrl + "/api/Brand", formData)
      .pipe(map(res => res.json()));
  }
  deleteBrand(id) {
    this.http
      .delete(this.baseUrl + "/api/Brand/" + id)
      .pipe(map(res => res.json()));
  }
}
