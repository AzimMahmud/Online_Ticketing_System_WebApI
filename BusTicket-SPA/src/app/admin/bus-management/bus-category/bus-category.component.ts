import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-bus-category',
  templateUrl: './bus-category.component.html',
  styleUrls: ['./bus-category.component.css']
})
export class BusCategoryComponent implements OnInit {

  modalRef: BsModalRef;
  message: string;
  constructor(private modalService: BsModalService) { }

  openModal(categoryModal: TemplateRef<any>) {
    this.modalRef = this.modalService.show(categoryModal);
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
