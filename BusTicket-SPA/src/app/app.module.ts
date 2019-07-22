import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from "./app.component";
import { ClientModule } from "./client/client.module";

import { BrandService } from "./_services/brand-service.service";
// import { BusAppRouteRoutes } from "./route/busAppRoute.routing";
import { ClientComponent } from "./client/client.component";
import { HomeComponent } from "./client/home/home.component";
import { BusSearchComponent } from "./client/bus-search/bus-search.component";
import { BusReservationComponent } from "./client/bus-reservation/bus-reservation.component";
import { DashboardComponent } from "./admin/dashboard/dashboard.component";
import { AdminModule } from "./admin/admin.module";
import { RootComponent } from "./root/root.component";

const routes: Routes = [
  { path: "", component: RootComponent },
  {
    path: "",
    component: AppComponent,
    children: [
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
      { path: "admin", component: DashboardComponent }
    ]
  }
];

@NgModule({
  declarations: [AppComponent, RootComponent],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    RouterModule.forChild([{ path: "admin", component: DashboardComponent }]),
    HttpClientModule,
    ClientModule,
    AdminModule
  ],
  providers: [BrandService],
  bootstrap: [AppComponent]
})
export class AppModule {}
