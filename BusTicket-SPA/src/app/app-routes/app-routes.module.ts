import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";
import { RootComponent } from "../root/root.component";
import { AppComponent } from "../app.component";
import { ClientComponent } from "../client/client.component";
import { HomeComponent } from "../client/home/home.component";
import { BusSearchComponent } from "../client/bus-search/bus-search.component";
import { BusReservationComponent } from "../client/bus-reservation/bus-reservation.component";
import { AdminHomeComponent } from "../admin/admin-home.component";
import { DashboardComponent } from "../admin/dashboard/dashboard.component";

const routes: Routes = [
  { path: "", component: RootComponent },
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
  },
  {
    path: "admin",
    component: AdminHomeComponent,
    children: [{ path: "dashboard", component: DashboardComponent }]
  }
];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(routes)],
  declarations: [],
  exports: [RouterModule]
})
export class AppRoutesModule {}
