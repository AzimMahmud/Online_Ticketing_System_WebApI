import { Component, OnInit } from "@angular/core";
import { Seat } from "src/app/models/seat.model";
import { Journey } from "src/app/models/journey.model";
import { Journey_Route } from "src/app/models/route.model";
import { Router } from "@angular/router";

@Component({
  selector: "app-ticket-print",
  templateUrl: "./ticket-print.component.html",
  styleUrls: ["./ticket-print.component.css"]
})
export class TicketPrintComponent implements OnInit {
  printDate: any;
  ticketInfo: any = {
    ticketResrvID: 0,
    ticketNo: "",
    passengerName: "",
    passengerPhoneNo: "",
    passengerEmail: "",
    gender: "",
    noOfTicket: 0,
    unitPrice: 0,
    seatNo: "",
    routeDetail: null,
    reservationDate: "",
    routeDetailID: 0,
    payments: [
      {
        paymentID: 0,
        paymentAmount: 0,
        paymentDate: "",
        transactionID: "",
        vendorName: "",
        ticketResrvID: 0,
        status: false
      }
    ]
  };
  journeyDetails: Journey;
  routeDetails: Journey_Route;
  constructor(private route: Router) {}

  ngOnInit() {
    this.ticketInfo = JSON.parse(localStorage.getItem("ticketReservationData"));
    this.journeyDetails = JSON.parse(localStorage.getItem("journey"));
    this.routeDetails = JSON.parse(localStorage.getItem("routeDetails"));
    this.printDate = new Date().toString();
  }

  back() {
    this.route.navigate(["client/home"]);
  }
}
