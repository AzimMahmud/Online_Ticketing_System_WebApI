import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { NgForm, FormControl } from "@angular/forms";
import { BsDatepickerConfig } from "ngx-bootstrap/datepicker";

import { CityList, HomeCity } from "src/app/_shared/Cities";
import { Observable } from "rxjs";
import { startWith, map } from "rxjs/operators";

@Component({
  templateUrl: "./home.component.html",
  styleUrls: []
})
export class HomeComponent implements OnInit {
  isCollapsed = false;
  private cityList = new HomeCity();
  cities = this.cityList.cities;

  bsValue = new Date();
  bsRangeValue: Date[];
  maxDate = new Date();
  dpConfig: Partial<BsDatepickerConfig> = new BsDatepickerConfig();

  constructor(private router: Router) {
    this.maxDate.setDate(this.maxDate.getDate() + 7);
    this.bsRangeValue = [this.bsValue, this.maxDate];
  }

  ngOnInit() {
    localStorage.removeItem("routeDetails");
    localStorage.removeItem("journey");
    localStorage.removeItem("ticketReservationData");
  }

  searchBus(form?: NgForm) {
    console.log(form);
    let leaving_form = form.value.picupPoint;
    let destination = form.value.dropPoint;
    let date = form.value.departDate;
    let datevalue = new Date(date).toLocaleDateString();

    this.router.navigate(["client/bookticket"], {
      queryParams: {
        bPoint: leaving_form,
        dPoint: destination,
        jDate: datevalue
      }
    });
  }
}
