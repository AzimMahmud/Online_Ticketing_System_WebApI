import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard/dashboard.component';
import { BusManagementComponent } from './bus-management/bus-management.component';
import { RouteManagementComponent } from './route-management/route-management.component';
import { VendorManagementComponent } from './vendor-management/vendor-management.component';
import { PromoOfferComponent } from './promo-offer/promo-offer.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [DashboardComponent, BusManagementComponent, RouteManagementComponent, VendorManagementComponent, PromoOfferComponent]
})
export class AdminModule { }
