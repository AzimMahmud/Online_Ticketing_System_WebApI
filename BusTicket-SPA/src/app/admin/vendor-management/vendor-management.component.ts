import { Component, OnInit } from "@angular/core";
import { IBrand } from "src/app/models/IBrand";
import { Observable } from "rxjs";

import { VendorService } from "src/app/_services/vendor.service";
import { IVendor } from "src/app/models/IVendor";

@Component({
  selector: "app-vendor-management",
  templateUrl: "./vendor-management.component.html",
  styleUrls: ["./vendor-management.component.css"]
})
export class VendorManagementComponent implements OnInit {
  vendors: IVendor;

  constructor(private vendorService: VendorService) {}

  ngOnInit() {
    this.refreshData();
  }

  refreshData() {
    this.vendorService.getVendors().subscribe(c => {
      console.log(c);
      this.vendors = c;
    });
  }
}
