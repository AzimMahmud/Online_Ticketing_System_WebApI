import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";

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

import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

import { BsDatepickerModule } from "ngx-bootstrap/datepicker";
import { TimepickerModule } from "ngx-bootstrap/timepicker";
import { TooltipModule } from "ngx-bootstrap/tooltip";

import { ModalModule } from "ngx-bootstrap/modal";
import { TypeaheadModule, CollapseModule } from "ngx-bootstrap";

@NgModule({
  declarations: [AppComponent, RootComponent],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    HttpModule,
    AppRoutesModule,
    ClientModule,
    AdminModule,
    ModalModule.forRoot(),
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot(),
    TimepickerModule.forRoot(),
    TooltipModule.forRoot(),
    TypeaheadModule.forRoot(),
    CollapseModule.forRoot()
  ],
  providers: [
    BrandService,
    VendorService,
    RouteService,
    DynamicScriptLoaderService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
