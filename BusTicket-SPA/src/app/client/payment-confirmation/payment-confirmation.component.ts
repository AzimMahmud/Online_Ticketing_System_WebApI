import { Component, OnInit, TemplateRef } from "@angular/core";
import { Journey_Route } from "src/app/models/route.model";
import { Seat } from "src/app/models/seat.model";
import { Journey } from "src/app/models/journey.model";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { TicketReservationService } from "src/app/_services/ticket-reservation.service";
import { Router } from "@angular/router";
import { BsModalService, BsModalRef } from "ngx-bootstrap";

@Component({
  selector: "app-payment-confirmation",
  templateUrl: "./payment-confirmation.component.html",
  styleUrls: ["./payment-confirmation.component.css"]
})
export class PaymentConfirmationComponent implements OnInit {
  modalRef: BsModalRef;
  submitted: boolean = false;
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
  paymentConfirmForm: FormGroup;
  constructor(
    private fb: FormBuilder,
    private service: TicketReservationService,
    private route: Router,
    private modalService: BsModalService
  ) {}

  get f() {
    return this.paymentConfirmForm.controls;
  }

  ngOnInit() {
    this.paymentConfirmForm = this.fb.group({
      transactionID: ["", Validators.required]
    });

    this.ticketInfo = JSON.parse(localStorage.getItem("ticketReservationData"));
    this.journeyDetails = JSON.parse(localStorage.getItem("journey"));
    this.routeDetails = JSON.parse(localStorage.getItem("routeDetails"));

    console.log(this.ticketInfo);
  }

  onSubmit(): void {
    this.submitted = true;

    // stop here if form is invalid
    if (this.paymentConfirmForm.invalid) {
      return;
    } else {
      if (
        this.paymentConfirmForm.get("transactionID").value ==
        this.ticketInfo.payments[0].transactionID
      ) {
        this.ticketInfo.payments[0].status = true;
        this.service
          .confirmPayment(this.ticketInfo.payments[0])
          .subscribe(res => console.log(res));
        alert("Successfully Purcase Ticket");

        this.route.navigate(["client/print"]);
      } else {
        console.log(this.paymentConfirmForm.get("transactionID").value);
        console.log(this.ticketInfo.payments);
        alert("Please Enter Valid TransactionID");
      }
    }
  }
}

// localStorage.removeItem("routeDetails");
