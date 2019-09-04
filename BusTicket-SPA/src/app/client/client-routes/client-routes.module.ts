import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Routes, RouterModule } from "@angular/router";
import { ClientComponent } from "../client.component";
import { HomeComponent } from "../home/home.component";
import { BusSearchComponent } from "../bus-search/bus-search.component";
import { BusReservationComponent } from "../bus-reservation/bus-reservation.component";
import { ContactComponent } from "../contact/contact.component";
import { TicketConfirmationComponent } from "../ticket-confirmation/ticket-confirmation.component";
import { PaymentConfirmationComponent } from "../payment-confirmation/payment-confirmation.component";
import { TicketPrintComponent } from "../ticket-print/ticket-print.component";

const routes: Routes = [
  {
    path: "client",
    component: ClientComponent,
    children: [
      { path: "home", component: HomeComponent },
      { path: "busreservation", component: BusReservationComponent },
      { path: "bookticket", component: BusSearchComponent },
      { path: "contact", component: ContactComponent },
      { path: "ticketconfermation", component: TicketConfirmationComponent },
      { path: "paymentconfirm", component: PaymentConfirmationComponent },
      { path: "print", component: TicketPrintComponent }
    ]
  }
];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(routes)],
  declarations: [],
  exports: [RouterModule]
})
export class ClientRoutesModule {}
