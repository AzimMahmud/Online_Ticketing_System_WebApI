import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";
import { Bus } from "src/app/models/bus.model";
import { Seat } from "src/app/models/seat.model";
import { Journey_Route } from "src/app/models/route.model";
import { Journey } from "src/app/models/journey.model";
import {
  RouteService,
  SelectedBusDetails
} from "src/app/_services/route.service";
import { Router } from "@angular/router";

@Component({
  selector: "bus-layout",
  templateUrl: "./bus-layout.component.html",
  styleUrls: ["./bus-layout.component.css"]
})
export class BusLayoutComponent implements OnInit {
  @Input("bus") bus: Bus;
  @Output("closeModal") closeModal = new EventEmitter();
  showSeatList: Seat[] = [];
  total = 0;
  fillupSeat = [];
  alert = false;
  selectedBusDetails: SelectedBusDetails;
  constructor(private service: RouteService, private route: Router) {}

  ngOnInit() {
    this.getbookSeat();
  }
  Seat(e) {
    let seats = [];
    seats = this.showSeatList.map(iteam => {
      return iteam.seatNo;
    });
    let id = document.getElementById(e);

    if (this.fillupSeat.indexOf(String(e)) < 0 && seats.indexOf(e) < 0) {
      if (this.showSeatList.length != 4 && this.showSeatList.length < 4) {
        id.innerHTML = `   <img src="../../../assets/images/fseat.png" alt="">`;

        let seat = {
          seatNo: e,
          fare: this.bus.fare,
          seatClass: this.bus.category == "Non-AC" ? "Economy" : "Business"
        };
        this.totalFare(seat.fare);
        this.showList(seat);
      } else {
        this.alert = true;
      }
    } else {
      id.innerHTML = `   <img src="../../../assets/images/bseat.png" alt="">`;

      this.removeFromList(e);
      this.total -= this.bus.fare;
      this.alert = false;
    }
  }

  showList(seat) {
    this.showSeatList.push(seat);
    console.log(this.showSeatList);
    console.log(this.fillupSeat);
  }

  removeFromList(seat) {
    for (const key in this.showSeatList) {
      if (this.showSeatList[key].seatNo == seat) {
        if (+key > -1) {
          this.showSeatList.splice(+key, 1);
        }
      }
    }
  }

  totalFare(fare) {
    console.log(fare);
    this.total += fare;
  }

  confirmJourney() {
    let route: Journey_Route = JSON.parse(localStorage.getItem("route"));

    let seats = [];
    seats = this.showSeatList.map(iteam => {
      return iteam.seatNo;
    });

    let journey: Journey = {
      bus: this.bus,
      seats: seats,
      noOfSeat: seats.length,
      fare: Number(this.total),
      journey_route: route
    };

    localStorage.setItem("journey", JSON.stringify(journey));
    this.route.navigate(["/client/ticketconfermation"]);
    this.closeModal.emit();
  }

  getbookSeat() {
    this.service.$isSeatBooked.subscribe(data => {
      for (let i of data.seates) {
        this.fillupSeat.push(i);
        this.changeSeatColor(i);
        console.log(data);
      }
    });
  }

  changeSeatColor(seatNo) {
    // let a = this.modalRef.content("A2")
    let id = document.getElementById(seatNo);
    console.log(seatNo);
    id.innerHTML = `  <img src="../../../assets/images/booked.png">`;
    id.removeEventListener("click", this.Seat);
    id.classList.add("isDisabled");
  }
}
