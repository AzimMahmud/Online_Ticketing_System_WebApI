import { Component, OnInit } from "@angular/core";
import { DynamicScriptLoaderService } from "../dynamic-script-loader-service.service";

@Component({
  templateUrl: "./client.component.html",
  styleUrls: ["./client.component.css"]
})
export class ClientComponent implements OnInit {
  constructor(private dynamicScriptLoader: DynamicScriptLoaderService) {}

  public ngOnInit() {
    this.loadScripts();
  }

  private loadScripts() {
    // You can load multiple scripts by just providing the key as argument into load method of the service
    this.dynamicScriptLoader
      .load()
      .then(data => {
        // Script Loaded Successfully
      })
      .catch(error => console.log(error));
  }
}
