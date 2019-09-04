import { Injectable } from "@angular/core";
import { HttpClient } from "../../../node_modules/@angular/common/http";
import { User } from "../models/user.model";

@Injectable({
  providedIn: "root"
})
export class AdminService {
  baseUrl: any;

  constructor(private http: HttpClient) {
    this.baseUrl = window.localStorage.getItem("apikey");
  }

  getUsersWithRoles() {
    return this.http.get(this.baseUrl + "admin/userswithroles");
  }

  updateUserRoles(user: User, roles: {}) {
    return this.http.post(
      this.baseUrl + "admin/editRoles/" + user.userName,
      roles
    );
  }
}
