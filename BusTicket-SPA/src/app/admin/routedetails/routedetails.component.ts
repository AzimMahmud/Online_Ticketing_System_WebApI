import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-routedetails',
  templateUrl: './routedetails.component.html',
  styleUrls: ['./routedetails.component.css']
})
export class RoutedetailsComponent implements OnInit {
  isMeridian = false;
  showSpinners = true;
  myTime: Date = new Date();
  modalRef: BsModalRef;
  message: string;
  constructor(private modalService: BsModalService) { }

  openModal(routeDetailsModal: TemplateRef<any>) {
    this.modalRef = this.modalService.show(
      routeDetailsModal,
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
