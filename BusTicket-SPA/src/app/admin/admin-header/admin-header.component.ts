import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: "admin-header",
  templateUrl: "./admin-header.component.html",
  styleUrls: ["./admin-header.component.css"]
})
export class AdminHeaderComponent implements OnInit {
  constructor(private route: Router) {}

  ngOnInit() {}

  logOut() {
    localStorage.removeItem("token");
    localStorage.removeItem("user");
    this.route.navigate(["login"]);
  }
}
