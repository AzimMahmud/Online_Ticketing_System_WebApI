import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Journey_Route } from "src/app/models/route.model";
import { Journey } from "src/app/models/journey.model";
import { ITicketReservation } from "src/app/models/ITicketReservation";
import { TicketReservationService } from "src/app/_services/ticket-reservation.service";
import { Observable } from "rxjs";
import { Router } from "@angular/router";

@Component({
  selector: "app-ticket-confirmation",
  templateUrl: "./ticket-confirmation.component.html",
  styleUrls: ["./ticket-confirmation.component.css"]
})
export class TicketConfirmationComponent implements OnInit {
  ticketConfirmForm: FormGroup;
  submitted = false;
  journeyDetails: Journey;
  routeDetails: Journey_Route = {
    boardPoint: "",
    dropPoint: "",
    journeyDate: ""
  };

  confirmForm: ITicketReservation = {
    ticketResrvID: 0,
    ticketNo: "",
    passengerName: "",
    passengerPhoneNo: "",
    passengerEmail: "",
    gender: "",
    noOfTicket: "",
    unitPrice: "",
    seatNo: "",
    routeDetailID: 0,
    reservationDate: "",
    paymentID: 0,
    transactionID: 0,
    paymentAmount: "",
    paymentDate: "",
    vendorName: ""
  };

  charge: any = 150;
  discount: any = 0;
  totalAmount: any = 0;

  isCollapsed = false;
  constructor(
    private fb: FormBuilder,
    private service: TicketReservationService,
    private route: Router
  ) {}

  ngOnInit() {
    this.journeyDetails = JSON.parse(localStorage.getItem("journey"));
    this.routeDetails = JSON.parse(localStorage.getItem("routeDetails"));

    this.totalAmount = this.journeyDetails.fare + this.discount + this.charge;

    this.ticketConfirmForm = this.fb.group({
      name: ["", Validators.required],
      phone: ["", [Validators.required, Validators.minLength(11)]],
      email: ["", [Validators.required, Validators.email]],
      gender: ["", Validators.required]
    });
  }

  get f() {
    return this.ticketConfirmForm.controls;
  }

  onSubmit(): void {
    this.submitted = true;
    const random = Math.floor(Math.random() * (999999 - 100000)) + 100000;

    // stop here if form is invalid
    if (this.ticketConfirmForm.invalid) {
      console.log(this.ticketConfirmForm);
      return;
    } else {
      this.confirmForm.ticketNo = "TK" + random;
      this.confirmForm.passengerName = this.ticketConfirmForm.get("name").value;
      this.confirmForm.passengerEmail = this.ticketConfirmForm.get(
        "email"
      ).value;
      this.confirmForm.passengerPhoneNo = this.ticketConfirmForm.get(
        "phone"
      ).value;
      this.confirmForm.gender = this.ticketConfirmForm.get("gender").value;
      this.confirmForm.noOfTicket = this.journeyDetails.noOfSeat;
      this.confirmForm.unitPrice = this.journeyDetails.bus.fare;
      this.confirmForm.seatNo = this.journeyDetails.seats.toString();
      this.confirmForm.reservationDate = this.routeDetails.journeyDate;
      this.confirmForm.routeDetailID = this.journeyDetails.bus.routeDetailID;
      this.confirmForm.paymentAmount = this.totalAmount;
      this.confirmForm.transactionID = "BKTR" + random;
      this.confirmForm.paymentDate = new Date().toDateString();
      this.confirmForm.vendorName = this.journeyDetails.bus.vendorName;
      this.service.postTicketReservation(this.confirmForm).subscribe(
        data => {
          // refresh the list

          this.ticketConfirmForm.reset();
          this.confirmForm = null;
          this.route.navigate(["/client/paymentconfirm"]);
          localStorage.setItem("ticketReservationData", JSON.stringify(data));
          return true;
        },
        error => {
          return Observable.throw(error);
        }
      );
      console.log(this.confirmForm);
    }
  }
}
