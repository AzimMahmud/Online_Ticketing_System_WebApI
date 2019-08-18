import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-ticket-reservation',
  templateUrl: './ticket-reservation.component.html',
  styleUrls: ['./ticket-reservation.component.css']
})
export class TicketReservationComponent implements OnInit {

  modalRef: BsModalRef;
  message: string;
  constructor(private modalService: BsModalService) { }

  openModal(ticketReservationModal: TemplateRef<any>) {
    this.modalRef = this.modalService.show(
      ticketReservationModal,
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
