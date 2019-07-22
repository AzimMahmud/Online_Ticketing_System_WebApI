import { Component } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"]
})
export class AppComponent {
  title = "app";
  coreApi: string = window.localStorage.getItem("coreApi");
  show: boolean = true;

  constructor(private route: Router) {}

  setCoreAPI() {
    window.localStorage.setItem("coreApi", "http://localhost:5000");
    this.route.navigate(["client/home"]);
    this.show = false;
    console.log(this.coreApi);
  }
}
