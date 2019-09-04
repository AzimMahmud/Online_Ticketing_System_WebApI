import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from "./app.component";
import { ClientModule } from "./client/client.module";

import { BrandService } from "./_services/brand-service.service";

import { AdminModule } from "./admin/admin.module";
import { RootComponent } from "./root/root.component";

import { AppRoutesModule } from "./app-routes/app-routes.module";
import { DynamicScriptLoaderService } from "./dynamic-script-loader-service.service";
import { HttpModule } from "@angular/http";
import { VendorService } from "./_services/vendor.service";
import { RouteService } from "./_services/route.service";
import { TabsModule } from "ngx-bootstrap/tabs";

import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

import { BsDatepickerModule } from "ngx-bootstrap/datepicker";
import { TimepickerModule } from "ngx-bootstrap/timepicker";
import { TooltipModule } from "ngx-bootstrap/tooltip";

import { NgxPrintModule } from 'ngx-print';

import { ModalModule } from "ngx-bootstrap/modal";
import { TypeaheadModule, CollapseModule } from "ngx-bootstrap";
import { ToastrModule } from "ngx-toastr";
import { NgxPaginationModule } from "ngx-pagination";

import { Ng2SearchPipeModule } from "ng2-search-filter";
import { Ng2OrderModule } from "ng2-order-pipe";
import { UniqueBrandNameDirective } from "./_shared/unique-brand-name.directive";
import { NgxMaterialTimepickerModule } from "ngx-material-timepicker";

// Material import statement
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
import { AuthGuard } from "./_guards/auth.guard";
import { AuthService } from "./_services/auth.service";
import { AlertifyService } from "./_services/alertify.service";
import { LoginComponent } from "./Auth/login/login.component";
@NgModule({
  declarations: [AppComponent, RootComponent, LoginComponent],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule,
    AppRoutesModule,

    NgxPrintModule,

    ClientModule,
    AdminModule,
    ModalModule.forRoot(),
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot(),
    TimepickerModule.forRoot(),
    TooltipModule.forRoot(),
    TypeaheadModule.forRoot(),
    CollapseModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 1000,
      positionClass: "toast-top-right",
      preventDuplicates: false
    }),
    NgxPaginationModule,
    Ng2SearchPipeModule,
    Ng2OrderModule,
    NgxMaterialTimepickerModule.forRoot(),

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
    TabsModule.forRoot()
  ],
  providers: [
    BrandService,
    VendorService,
    RouteService,
    DynamicScriptLoaderService,
    AuthService,
    AuthGuard,
    AlertifyService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
