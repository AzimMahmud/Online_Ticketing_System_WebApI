import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: "app-root",
  templateUrl: "./root.component.html",
  styleUrls: ["./root.component.css"]
})
export class RootComponent implements OnInit {
  constructor(private route: Router) {}
  localStorage = window.localStorage;
  show: boolean = true;
  ngOnInit() {
    if (localStorage.length !== 0) {
      this.localStorage.clear();
    }
  }

  setCoreAPI() {
    window.localStorage.setItem("apikey", "http://localhost:5000");
    this.route.navigate(["client/home"]);
    this.show = false;
  }

  setWebAPI() {
    window.localStorage.setItem("apikey", "http://localhost:2663");
    this.route.navigate(["client/home"]);
    this.show = false;
  }
}
