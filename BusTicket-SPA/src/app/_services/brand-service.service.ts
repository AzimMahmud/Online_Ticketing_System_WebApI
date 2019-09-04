import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { map } from "rxjs/operators";
import { IBrand } from "../models/IBrand";

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

  getArchiveBrands() {
    return this.http
      .get(this.baseUrl + "/api/Brand/GetArchive")
      .pipe(map(res => res.json()));
  }

  getBrandById(id: number) {
    return this.http
      .get(this.baseUrl + "/api/Brand/" + id)
      .pipe(map(res => res.json()));
  }

  createBrand(formData: any) {
    return this.http
      .post(this.baseUrl + "/api/Brand", formData)
      .pipe(map(res => res.json()));
  }
  updateBrand(id: number, formData: IBrand) {
    formData.brandId = id;
    return this.http
      .put(this.baseUrl + "/api/Brand", formData)
      .pipe(map(res => res.json()));
  }
  softDelete(brandID: number) {
    return this.http
      .put(this.baseUrl + "/api/Brand/BrandDelete/" + brandID, null)
      .pipe(map(res => res.json()));
  }
  deleteBrand(id) {
    return this.http
      .delete(this.baseUrl + "/api/Brand/" + id)
      .pipe(map(res => res.json()));
  }
}
