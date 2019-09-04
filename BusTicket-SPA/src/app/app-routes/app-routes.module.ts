import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes, PreloadAllModules } from "@angular/router";
import { RootComponent } from "../root/root.component";
import { AppComponent } from "../app.component";
import { ClientComponent } from "../client/client.component";
import { HomeComponent } from "../client/home/home.component";
import { BusSearchComponent } from "../client/bus-search/bus-search.component";
import { BusReservationComponent } from "../client/bus-reservation/bus-reservation.component";
import { AdminHomeComponent } from "../admin/admin-home.component";
import { DashboardComponent } from "../admin/dashboard/dashboard.component";
import { AdminRoutesModule } from "../admin/admin-routes/admin-routes.module";
import { ClientRoutesModule } from "../client/client-routes/client-routes.module";
import { LoginComponent } from "../Auth/login/login.component";

const routes: Routes = [
  { path: "", component: RootComponent, pathMatch: "full" },
  { path: "login", component: LoginComponent }
];

@NgModule({
  imports: [CommonModule, RouterModule.forRoot(routes), ClientRoutesModule],
  declarations: [],
  exports: [RouterModule, ClientRoutesModule, AdminRoutesModule]
})
export class AppRoutesModule {}
