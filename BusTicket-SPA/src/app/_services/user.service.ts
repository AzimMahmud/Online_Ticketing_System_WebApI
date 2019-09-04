import { Injectable } from "@angular/core";

import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { User } from "../models/user.model";

@Injectable({
  providedIn: "root"
})
export class UserService {
  baseUrl: any;

  constructor(private http: HttpClient) {
    this.baseUrl = window.localStorage.getItem("apikey");
  }

  getUser(id): Observable<User> {
    return this.http.get<User>(this.baseUrl + "users/" + id);
  }

  updateUser(id: number, user: User) {
    return this.http.put(this.baseUrl + "users/" + id, user);
  }
}
