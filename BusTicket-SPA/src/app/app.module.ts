import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from "./app.component";
import { ClientModule } from "./client/client.module";

import { BrandService } from "./_services/brand-service.service";

import { AdminModule } from "./admin/admin.module";
import { RootComponent } from "./root/root.component";
import { AdminHomeComponent } from "./admin/admin-home.component";
import { AppRoutesModule } from "./app-routes/app-routes.module";
import { DynamicScriptLoaderService } from "./dynamic-script-loader-service.service";
import { HttpModule } from "@angular/http";
import { VendorService } from "./_services/vendor.service";
import { RouteService } from "./_services/route.service";

@NgModule({
  declarations: [AppComponent, RootComponent, AdminHomeComponent],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    HttpModule,
    AppRoutesModule,
    ClientModule,
    AdminModule
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
