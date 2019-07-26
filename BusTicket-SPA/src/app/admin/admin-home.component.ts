import { Component, OnInit } from "@angular/core";
import { DynamicScriptLoaderService } from "../dynamic-script-loader-service.service";

@Component({
  selector: "app-admin-home",
  templateUrl: "./admin-home.component.html",
  styleUrls: ["./admin-home.component.css"]
})
export class AdminHomeComponent implements OnInit {
  constructor(private dynamicScriptLoader: DynamicScriptLoaderService) {}

  public ngOnInit() {
    this.loadScripts();
  }

  private loadScripts() {
    this.dynamicScriptLoader
      .load(
        "jquery-client",
        "popper",
        "bootstrap",
        "perfectScrollbar",
        "wave",
        "sticky-kit",
        "sparkline",
        "sidebarmenu-admin",
        "custom-admin"
      )
      .then(data => {
        // Script Loaded Successfully
      })
      .catch(error => console.log(error));
  }
}
