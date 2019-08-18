import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';



@Component({
  selector: 'app-vendor-payment',
  templateUrl: './vendor-payment.component.html',
  styleUrls: ['./vendor-payment.component.css']
})
export class VendorPaymentComponent implements OnInit {

  modalRef: BsModalRef;
  message: string;
  constructor(private modalService: BsModalService) { }

  openModal(vendorPaymentModal: TemplateRef<any>) {
    this.modalRef = this.modalService.show(
      vendorPaymentModal,
      Object.assign({}, { class: 'gray modal-lg' })
    );
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
