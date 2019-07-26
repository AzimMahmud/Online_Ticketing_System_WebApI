import { Component, OnInit } from "@angular/core";

import { IPromoOffer } from "src/app/models/IPromoOffer";
import { PromoService } from "src/app/_services/promo.service";

@Component({
  selector: "app-promo-offer",
  templateUrl: "./promo-offer.component.html",
  styleUrls: ["./promo-offer.component.css"]
})
export class PromoOfferComponent implements OnInit {
  promoOffers: IPromoOffer;

  constructor(private service: PromoService) {}

  ngOnInit() {
    this.refreshData();
  }
  refreshData() {
    this.service.getPromo().subscribe(p => {
      console.log(p);
      this.promoOffers = p;
    });
  }
}
