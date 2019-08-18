import { Component, OnInit } from "@angular/core";
import { ITicketReservation } from "src/app/models/ITicketReservation";
import { TicketReservationService } from "src/app/_services/ticket-reservation.service";

@Component({
  selector: "app-ticket-reservation",
  templateUrl: "./ticket-reservation.component.html",
  styleUrls: ["./ticket-reservation.component.css"]
})
export class TicketReservationComponent implements OnInit {
  ticketReservation: ITicketReservation;

  constructor(private service: TicketReservationService) {}

  ngOnInit() {
    this.refreshData();
  }

  refreshData() {
    this.service.getTicketReservations().subscribe(tr => {
      this.ticketReservation = tr;
    });
  }
}
