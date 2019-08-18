import { Component, OnInit } from "@angular/core";

import { IRouteAvailabilityDetails } from "src/app/models/IRouteAvailabilityDetails";
import { RouteService } from "src/app/_services/route.service";
import { ActivatedRoute, Router } from "@angular/router";
import { NgForm } from "@angular/forms";

@Component({
  selector: "app-bus-search",
  templateUrl: "./bus-search.component.html",
  styleUrls: ["./bus-search.component.css"]
})
export class BusSearchComponent implements OnInit {
  rotDetails: any;
  boardPoint: string;
  dropPoint: string;
  journeyDate: string;
  constructor(
    private service: RouteService,
    private activeRoute: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.activeRoute.queryParams.subscribe(queryParams => {
      this.boardPoint = queryParams["bPoint"];
      this.dropPoint = queryParams["dPoint"];
      this.journeyDate = decodeURIComponent(queryParams["jDate"]);
      this.refreshData();
    });
  }

  refreshData() {
    this.service
      .getRoutes(this.boardPoint, this.dropPoint, this.journeyDate)
      .subscribe(p => {
        this.rotDetails = p;
        
      });
  }

  seatAvailableCheck(routeid: any) {
    var data;
    for (let i = 0; i < this.rotDetails.availableSeat.length; i++) {
      if (this.rotDetails.availableSeat[i].routeID === routeid) {
        data = this.rotDetails.availableSeat[i].availabaleSeat;
      }
    }
    return data;
  }

  searchBus(form?: NgForm) {
    console.log(form);
    let leaving_form = form.value.pickLocation;
    let destination = form.value.dropLocation;
    let date = form.value.departDate;
    this.router.navigate(["client/bookticket"], {
      queryParams: { bPoint: leaving_form, dPoint: destination, jDate: date }
    });
  }
}
