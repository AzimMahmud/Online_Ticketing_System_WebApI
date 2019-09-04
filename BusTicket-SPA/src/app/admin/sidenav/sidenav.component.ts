import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: "app-sidenav",
  templateUrl: "./sidenav.component.html",
  styleUrls: ["./sidenav.component.css"]
})
export class SidenavComponent implements OnInit {
  constructor(private route: Router) {}

  ngOnInit() {}

  logOut() {
    localStorage.removeItem("token");
    localStorage.removeItem("user");
    this.route.navigate(["login"]);
  }
}
