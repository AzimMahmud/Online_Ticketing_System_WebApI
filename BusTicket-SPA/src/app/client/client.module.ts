import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";
import {
  BsDatepickerModule,
  TypeaheadModule,
  CollapseModule
} from "ngx-bootstrap";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

import { HomeComponent } from "./home/home.component";
import { NavComponent } from "./nav/nav.component";
import { FooterComponent } from "./footer/footer.component";
import { BusSearchComponent } from "./bus-search/bus-search.component";
import { TicketReservationComponent } from "./ticket-reservation/ticket-reservation.component";
import { BusReservationComponent } from "./bus-reservation/bus-reservation.component";
import { ContactComponent } from "./contact/contact.component";
import { AboutComponent } from "./about/about.component";
import { CancelTicketComponent } from "./cancel-ticket/cancel-ticket.component";
import { ClientComponent } from "./client.component";

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    CollapseModule,
    BsDatepickerModule,
    TypeaheadModule,
    BrowserAnimationsModule
  ],
  declarations: [
    HomeComponent,
    NavComponent,
    FooterComponent,
    BusSearchComponent,
    TicketReservationComponent,
    BusReservationComponent,
    ContactComponent,
    AboutComponent,
    CancelTicketComponent,
    ClientComponent
  ]
})
export class ClientModule {}
