import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';


@Component({
  selector: 'app-brand',
  templateUrl: './brand.component.html',
  styleUrls: ['./brand.component.css']
})
export class BrandComponent implements OnInit {
  modalRef: BsModalRef;

  message: string;

  constructor(private modalService: BsModalService) { }

  openModal(brandModal: TemplateRef<any>) {
    this.modalRef = this.modalService.show(brandModal); 
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
