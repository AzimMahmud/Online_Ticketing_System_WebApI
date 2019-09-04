import { Component, OnInit } from "@angular/core";
import { DashboardService } from "src/app/_services/dashboard.service";

@Component({
  selector: "app-dashboard",
  templateUrl: "./dashboard.component.html",
  styleUrls: ["./dashboard.component.css"]
})
export class DashboardComponent implements OnInit {
  totalVendor: any = {
    totalVendor: 0
  };

  totalSales: any = {
    totalSales: 0
  };
  constructor(private service: DashboardService) {}

  ngOnInit() {
    this.service.getAllVendor().subscribe(res => (this.totalVendor = res));
    this.service.getTotalSales().subscribe(res => (this.totalSales = res));
  }
}
