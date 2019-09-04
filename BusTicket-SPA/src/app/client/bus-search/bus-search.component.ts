import {
  Component,
  OnInit,
  TemplateRef,
  Input,
  ElementRef,
  ViewChild,
  EventEmitter
} from "@angular/core";

import { IRouteAvailabilityDetails } from "src/app/models/IRouteAvailabilityDetails";
import {
  RouteService,
  SelectedBusDetails
} from "src/app/_services/route.service";
import { ActivatedRoute, Router } from "@angular/router";
import { NgForm } from "@angular/forms";
import { HomeCity } from "src/app/_shared/Cities";
import { BsModalService, BsModalRef } from "ngx-bootstrap";
import { Bus } from "src/app/models/bus.model";
import { Seat } from "src/app/models/seat.model";
import { Journey_Route } from "src/app/models/route.model";
import { Journey } from "src/app/models/journey.model";
import { BusLayoutComponent } from "../bus-layout/bus-layout.component";

declare var $: any;

@Component({
  selector: "app-bus-search",
  templateUrl: "./bus-search.component.html",
  styleUrls: ["./bus-search.component.css"]
})
export class BusSearchComponent implements OnInit {
  isCollapsed = true;
  private city = new HomeCity();
  cities = this.city.cities;
  modalRef: BsModalRef;
  rotDetails: any;
  boardPoint: string;
  dropPoint: string;
  journeyDate: string;
  key: string = "name";
  reverse: boolean = false;

  routeId: number;

  routeDetails: Journey_Route = {
    boardPoint: "",
    dropPoint: "",
    journeyDate: ""
  };

  model: any = {
    departDate: "",
    picupPoint: "",
    dropPoint: ""
  };
  constructor(
    private service: RouteService,
    private activeRoute: ActivatedRoute,
    private router: Router,
    private modalService: BsModalService
  ) {}

  ngOnInit() {
    this.activeRoute.queryParams.subscribe(queryParams => {
      localStorage.removeItem("routeDetails"),
        localStorage.removeItem("journey"),
        (this.boardPoint = queryParams["bPoint"]);
      this.dropPoint = queryParams["dPoint"];
      this.journeyDate = decodeURIComponent(queryParams["jDate"]);

      this.routeDetails.boardPoint = this.boardPoint;
      this.routeDetails.dropPoint = this.dropPoint;
      this.routeDetails.journeyDate = $.datepicker.formatDate(
        "yy-mm-dd",
        new Date(this.journeyDate)
      );

      this.model.departDate = this.journeyDate;
      this.model.picupPoint = this.boardPoint;
      this.model.dropPoint = this.dropPoint;
      localStorage.setItem("routeDetails", JSON.stringify(this.routeDetails));
      this.refreshData();
    });
  }

  sort(key) {
    this.key = key;
    this.reverse = !this.reverse;
  }

  refreshData() {
    this.service
      .getRoutesForTicketReservation(
        this.boardPoint,
        this.dropPoint,
        this.journeyDate
      )
      .subscribe(p => {
        this.rotDetails = p;
      });
  }

  seatAvailableCheck(routeid: any) {
    var data;
    for (let i = 0; i < this.rotDetails.availableSeat.length; i++) {
      if (this.rotDetails.availableSeat[i].routeDetailID === routeid) {
        data = this.rotDetails.availableSeat[i].availabaleSeat;
      }
    }

    return data;
  }

  searchBus(form?: NgForm) {
    // console.log(form);
    let leaving_form = form.value.picupPoint;
    let destination = form.value.dropPoint;
    let date = new Date(form.value.departDate).toLocaleDateString();
    this.router.navigate(["client/bookticket"], {
      queryParams: { bPoint: leaving_form, dPoint: destination, jDate: date }
    });
  }

  // Seat Layout
  loadSeatLayout(seatLayoutModal: TemplateRef<any>, routeID: number): void {
    this.modalRef = this.modalRef = this.modalService.show(seatLayoutModal, {
      class: "modal-lg"
    });

    this.getbookedSeat(routeID);
  }

  getbookedSeat(routeID: number) {
    var seats: string[];
    for (let i = 0; i < this.rotDetails.availableSeat.length; i++) {
      if (this.rotDetails.availableSeat[i].routeDetailID === routeID) {
        seats = this.rotDetails.availableSeat[i].seatNumbers.split(",");
      }
    }

    return this.service.getSelectedSeatDetails(routeID, seats);
  }

  openModal(template: TemplateRef<any>, bus) {
    this.modalRef = this.modalService.show(template);
  }
  closeModal() {
    this.modalRef.hide();
  }
}
