import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import {
  BsDatepickerModule,
  TypeaheadModule,
  CollapseModule
} from "ngx-bootstrap";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { TabsModule } from "ngx-bootstrap/tabs";

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
import { Ng2OrderModule } from "ng2-order-pipe";
import { BusLayoutComponent } from "./bus-layout/bus-layout.component";
import { TicketConfirmationComponent } from "./ticket-confirmation/ticket-confirmation.component";
import { PaymentConfirmationComponent } from "./payment-confirmation/payment-confirmation.component";
import { AlertifyService } from "../_services/alertify.service";
import { TicketPrintComponent } from './ticket-print/ticket-print.component';
import { NgxPrintModule } from 'ngx-print';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    CollapseModule,
    BsDatepickerModule,
    TypeaheadModule,
    BrowserAnimationsModule,
    Ng2OrderModule,
    TabsModule,
    NgxPrintModule
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
    ClientComponent,
    BusLayoutComponent,
    TicketConfirmationComponent,
    PaymentConfirmationComponent,
    TicketPrintComponent
  ],
  providers: [AlertifyService]
})
export class ClientModule {}
