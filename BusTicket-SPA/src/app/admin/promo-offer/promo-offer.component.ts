import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: "app-promo-offer",
  templateUrl: "./promo-offer.component.html",
  styleUrls: ["./promo-offer.component.css"]
})
export class PromoOfferComponent implements OnInit {
  modalRef: BsModalRef;
  message: string;

  constructor(private modalService: BsModalService) { }

  openModal(promoModal: TemplateRef<any>) {
    this.modalRef = this.modalService.show(promoModal);
  }
  confirmModal(deleteConfirmation: TemplateRef<any>) {
    this.modalRef = this.modalService.show(deleteConfirmation, { class: 'modal-sm' });

  }
  confirm(): void {
    this.message = 'Confirmed!';
    this.modalRef.hide();
  }

  decline(): void {
    this.message = 'Declined!';
    this.modalRef.hide();
  }

  ngOnInit() {

  }
}
