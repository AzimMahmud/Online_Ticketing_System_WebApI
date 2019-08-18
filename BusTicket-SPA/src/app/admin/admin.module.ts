import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";
import { CommonModule } from "@angular/common";
import { DashboardComponent } from "./dashboard/dashboard.component";


import { PromoOfferComponent } from "./promo-offer/promo-offer.component";

import { SidenavComponent } from "./sidenav/sidenav.component";
import { AdminHeaderComponent } from "./admin-header/admin-header.component";
import { AdminHomeComponent } from "./admin-home.component";
import { RouterModule } from "@angular/router";
import { BrandComponent } from "./bus-management/brand/brand.component";
import { BusCategoryComponent } from './bus-management/bus-category/bus-category.component';
import { BusDetailsComponent } from './bus-management/bus-details/bus-details.component';
import { RoutedetailsComponent } from './routedetails/routedetails.component';

import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { TimepickerModule } from 'ngx-bootstrap/timepicker';
import { TooltipModule } from 'ngx-bootstrap/tooltip';

import { TicketReservationComponent } from './reservation/ticket-reservation/ticket-reservation.component';
import { BusReservationComponent } from './reservation/bus-reservation/bus-reservation.component';
import { VendorComponent } from './vendor/vendor/vendor.component';
import { VendorPaymentComponent } from './vendor/vendor-payment/vendor-payment.component';
import { FooterComponent } from './footer/footer.component';
import { UserComponent } from './user/user/user.component';
import { UserProfileComponent } from './user/user-profile/user-profile.component';









@NgModule({
  imports: [CommonModule, RouterModule, BsDatepickerModule, TimepickerModule, TooltipModule],
  declarations: [
    DashboardComponent,
    
      
    PromoOfferComponent,
   
    SidenavComponent,
    AdminHeaderComponent,
    AdminHomeComponent,
    BrandComponent,
    BusCategoryComponent,
    BusDetailsComponent,
    RoutedetailsComponent,
 
    TicketReservationComponent,
 
    BusReservationComponent,
 
    VendorComponent,
 
    VendorPaymentComponent,
 
    FooterComponent,
 
    UserComponent,
 
    UserProfileComponent
  
   

      
   
   
   

 
  
  ]
})
export class AdminModule {}
