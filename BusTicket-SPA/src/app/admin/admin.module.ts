import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";
import { CommonModule } from "@angular/common";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { ToastrModule } from "ngx-toastr";

import { PromoOfferComponent } from "./promo-offer/promo-offer.component";
import { SidenavComponent } from "./sidenav/sidenav.component";
import { AdminHeaderComponent } from "./admin-header/admin-header.component";
import { AdminHomeComponent } from "./admin-home.component";
import { RouterModule } from "@angular/router";
import { BrandComponent } from "./bus-management/brand/brand.component";
import { BusCategoryComponent } from "./bus-management/bus-category/bus-category.component";
import { BusDetailsComponent } from "./bus-management/bus-details/bus-details.component";
import { RoutedetailsComponent } from "./routedetails/routedetails.component";

import { PaymentConfirmationComponent } from './reservation/payment-confirmation/payment-confirmation.component';
import { TicketConfirmationComponent } from './reservation/ticket-confirmation/ticket-confirmation.component';
import { TicketPrintComponent } from './reservation/ticket-print/ticket-print.component';
import { TicketReservationDetailsComponent } from './reservation/ticket-reservation-details/ticket-reservation-details.component';
import { BusReservationDetailsComponent } from './reservation/bus-reservation-details/bus-reservation-details.component';

import { NgxPrintModule } from 'ngx-print';


import {
  BsDatepickerModule,
  TimepickerModule,
  TooltipModule
} from "ngx-bootstrap";
import { NgxPaginationModule } from "ngx-pagination";

import { Ng2SearchPipeModule } from "ng2-search-filter";
import { Ng2OrderModule } from "ng2-order-pipe";

import { TicketReservationComponent } from "./reservation/ticket-reservation/ticket-reservation.component";
import { BusReservationComponent } from "./reservation/bus-reservation/bus-reservation.component";
import { VendorComponent } from "./vendor/vendor/vendor.component";
import { VendorPaymentComponent } from "./vendor/vendor-payment/vendor-payment.component";
import { FooterComponent } from "./footer/footer.component";
import { UserComponent } from "./user/user/user.component";
import { UserProfileComponent } from "./user/user-profile/user-profile.component";

// Time Picker
import { NgxMaterialTimepickerModule } from "ngx-material-timepicker";

// Material Import Statement
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MatCheckboxModule } from "@angular/material";
import { MatButtonModule } from "@angular/material";
import { MatInputModule } from "@angular/material/input";
import { MatAutocompleteModule } from "@angular/material/autocomplete";
import { MatDatepickerModule } from "@angular/material/datepicker";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatRadioModule } from "@angular/material/radio";
import { MatSelectModule } from "@angular/material/select";
import { MatSliderModule } from "@angular/material/slider";
import { MatSlideToggleModule } from "@angular/material/slide-toggle";
import { MatMenuModule } from "@angular/material/menu";
import { MatSidenavModule } from "@angular/material/sidenav";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatListModule } from "@angular/material/list";
import { MatGridListModule } from "@angular/material/grid-list";
import { MatCardModule } from "@angular/material/card";
import { MatStepperModule } from "@angular/material/stepper";
import { MatTabsModule } from "@angular/material/tabs";
import { MatExpansionModule } from "@angular/material/expansion";
import { MatButtonToggleModule } from "@angular/material/button-toggle";
import { MatChipsModule } from "@angular/material/chips";
import { MatIconModule } from "@angular/material/icon";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { MatProgressBarModule } from "@angular/material/progress-bar";
import { MatDialogModule } from "@angular/material/dialog";
import { MatTooltipModule } from "@angular/material/tooltip";
import { MatSnackBarModule } from "@angular/material/snack-bar";
import { MatTableModule } from "@angular/material/table";
import { MatSortModule } from "@angular/material/sort";
import { MatPaginatorModule } from "@angular/material/paginator";
import { MatNativeDateModule } from "@angular/material";
import { AuthService } from "../_services/auth.service";
import { AuthGuard } from "../_guards/auth.guard";
import { AlertifyService } from "../_services/alertify.service";

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    BsDatepickerModule,
    TimepickerModule,
    TooltipModule,
    ToastrModule,
    NgxPaginationModule,
    Ng2SearchPipeModule,
    Ng2OrderModule,
    NgxMaterialTimepickerModule,

    BrowserAnimationsModule,
    MatCheckboxModule,
    MatCheckboxModule,
    MatButtonModule,
    MatInputModule,
    MatAutocompleteModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatRadioModule,
    MatSelectModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatMenuModule,
    MatSidenavModule,
    MatToolbarModule,
    MatListModule,
    MatGridListModule,
    MatCardModule,
    MatStepperModule,
    MatTabsModule,
    MatExpansionModule,
    MatButtonToggleModule,
    MatChipsModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatProgressBarModule,
    MatDialogModule,
    MatTooltipModule,
    MatSnackBarModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatNativeDateModule,
    NgxPrintModule
  ],
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
    UserProfileComponent,
    UserComponent,
    PaymentConfirmationComponent, TicketConfirmationComponent, TicketPrintComponent, TicketReservationDetailsComponent, BusReservationDetailsComponent

  ],
  providers: [AuthService, AuthGuard, AlertifyService]
})
export class AdminModule {}
