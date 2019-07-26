import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";

import { AdminHomeComponent } from "../admin-home.component";
import { DashboardComponent } from "../dashboard/dashboard.component";
import { PromoOfferComponent } from "../promo-offer/promo-offer.component";
import { VendorManagementComponent } from "../vendor-management/vendor-management.component";
import { RouteManagementComponent } from "../route-management/route-management.component";

const routes: Routes = [
  {
    path: "admin",
    component: AdminHomeComponent,
    children: [
      { path: "dashboard", component: DashboardComponent },
      { path: "promo", component: PromoOfferComponent },
      { path: "vendor", component: VendorManagementComponent },
      { path: "routes", component: RouteManagementComponent }
    ]
  }
];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(routes)],
  declarations: [],
  exports: [RouterModule]
})
export class AdminRoutesModule {}
