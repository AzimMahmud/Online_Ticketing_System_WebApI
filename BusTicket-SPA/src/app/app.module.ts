import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from "./app.component";
import { ClientModule } from "./client/client.module";

import { BrandService } from "./_services/brand-service.service";

import { AdminModule } from "./admin/admin.module";
import { RootComponent } from "./root/root.component";
import { AdminHomeComponent } from "./admin/admin-home.component";
import { AppRoutesModule } from "./app-routes/app-routes.module";

@NgModule({
  declarations: [AppComponent, RootComponent, AdminHomeComponent],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([]),
    AppRoutesModule,
    ClientModule,
    AdminModule
  ],
  providers: [BrandService],
  bootstrap: [AppComponent]
})
export class AppModule {}
