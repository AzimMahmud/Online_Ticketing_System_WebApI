import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Routes, RouterModule } from "@angular/router";
import { ClientComponent } from "../client.component";
import { HomeComponent } from "../home/home.component";
import { BusSearchComponent } from "../bus-search/bus-search.component";
import { BusReservationComponent } from "../bus-reservation/bus-reservation.component";
import { ContactComponent } from "../contact/contact.component";
import { AboutComponent } from "../about/about.component";

const routes: Routes = [
  {
    path: "client",
    component: ClientComponent,
    children: [
      { path: "home", component: HomeComponent },
      { path: "busreservation", component: BusReservationComponent },
      { path: "bookticket", component: BusSearchComponent },
      { path: "contact", component: ContactComponent },
      

    ]
  }
];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(routes)],
  declarations: [],
  exports: [RouterModule]
})
export class ClientRoutesModule {}
