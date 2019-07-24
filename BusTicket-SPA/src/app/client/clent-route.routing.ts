import { Routes, RouterModule } from "@angular/router";
import { ClientComponent } from "./client.component";
import { HomeComponent } from "./home/home.component";
import { BusSearchComponent } from "./bus-search/bus-search.component";
import { BusReservationComponent } from "./bus-reservation/bus-reservation.component";

const routes: Routes = [
  {
    path: "client",
    component: ClientComponent,
    children: [
      { path: "home", component: HomeComponent },
      {
        path: "searchBus/:bPoint/:dPoint/:rDate",
        component: BusSearchComponent
      },
      { path: "busReservation", component: BusReservationComponent }
    ]
  }
];

export const ClentRouteRoutes = RouterModule.forChild(routes);
