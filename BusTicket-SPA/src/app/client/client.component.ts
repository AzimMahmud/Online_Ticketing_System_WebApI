import { Component, OnInit } from "@angular/core";

@Component({
  templateUrl: "./client.component.html",
  styleUrls: ["./client.component.css"]
})
export class ClientComponent implements OnInit {
  constructor() {}

  ngOnInit() {
    console.log(window.localStorage.key(0));
  }
}
