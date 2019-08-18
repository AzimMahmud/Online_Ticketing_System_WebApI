import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";

import { AdminHomeComponent } from "../admin-home.component";
import { DashboardComponent } from "../dashboard/dashboard.component";
import { PromoOfferComponent } from "../promo-offer/promo-offer.component";



import { BrandComponent } from "../bus-management/brand/brand.component";
import { BusCategoryComponent } from "../bus-management/bus-category/bus-category.component";
import { BusDetailsComponent } from "../bus-management/bus-details/bus-details.component";
import { RoutedetailsComponent } from "../routedetails/routedetails.component";
import { TicketReservationComponent } from "../reservation/ticket-reservation/ticket-reservation.component";
import { BusReservationComponent } from "../reservation/bus-reservation/bus-reservation.component";
import { VendorComponent } from "../vendor/vendor/vendor.component";
import { VendorPaymentComponent } from "../vendor/vendor-payment/vendor-payment.component";
import { UserComponent } from "../user/user/user.component";
import { UserProfileComponent } from "../user/user-profile/user-profile.component";

const routes: Routes = [
  {
    path: "admin",
    component: AdminHomeComponent,
    children: [
      { path: "dashboard", component: DashboardComponent },
      { path: "promo", component: PromoOfferComponent },
      { path: "brand", component: BrandComponent },
      { path: "busCategory", component: BusCategoryComponent },
      { path: "busDetails", component: BusDetailsComponent },
      { path: "routeDetails", component: RoutedetailsComponent },
      { path: "vendor", component: VendorComponent},
      { path: "vendorPayment", component: VendorPaymentComponent},
      { path: "user", component: UserComponent},
      { path: "userProfile", component: UserProfileComponent},
      
      { path: "busReservation", component: BusReservationComponent},
      { path: "ticketReservation", component: TicketReservationComponent}
     
    ]
  }
];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(routes)],
  declarations: [],
  exports: [RouterModule]
})
export class AdminRoutesModule { }
