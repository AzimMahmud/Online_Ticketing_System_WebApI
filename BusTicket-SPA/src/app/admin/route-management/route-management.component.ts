import { Component, OnInit } from "@angular/core";
import { RouteService } from "src/app/_services/route.service";
import { IRoutesDetails } from "src/app/models/IRoutesDetails";

@Component({
  selector: "app-route-management",
  templateUrl: "./route-management.component.html",
  styleUrls: ["./route-management.component.css"]
})
export class RouteManagementComponent implements OnInit {
  routes: IRoutesDetails;

  constructor(private routeService: RouteService) {}

  ngOnInit() {
    this.refreshData();
  }

  refreshData() {
    this.routeService.getRoutes().subscribe(r => {
      console.log(r);
      this.routes = r;
    });
  }
}
