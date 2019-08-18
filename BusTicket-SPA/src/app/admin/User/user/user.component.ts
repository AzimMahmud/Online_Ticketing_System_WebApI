import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  modalRef: BsModalRef;
  message: string;
  constructor(private modalService: BsModalService) { }

  openModal(userModal: TemplateRef<any>) {
    this.modalRef = this.modalService.show(
      userModal,
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
