import { Component, OnInit, TemplateRef } from '@angular/core';
import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder
} from "@angular/forms";
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { PromoService } from "src/app/_services/promo.service";
import { IPromoOffer } from "src/app/models/IPromoOffer";
import { Observable } from "rxjs";
import { ToastrService } from "ngx-toastr";


@Component({
  templateUrl: "./promo-offer.component.html",
  styleUrls: ["./promo-offer.component.css"]
})
export class PromoOfferComponent implements OnInit {
  allPromo: Observable<IPromoOffer[]>;

  submitted = false;
  idForUpdate = null;
  idForDelete = null;
  btnText = "";
  promoForm: FormGroup;

  modalRef: BsModalRef;
  message: string;

  config: any;
  key: string = "name";
  p: number = 1;
  row: number = 2;
  reverse: boolean = false;

  constructor(
    private modalService: BsModalService,
    private fbuilder: FormBuilder,
    private promoService: PromoService,
    private toastService: ToastrService) { }

  ngOnInit() {
    this.loadPromo("active");
    this.createForm();
  }
  sort(key) {
    this.key = key;
    this.reverse = !this.reverse;
  }
  createForm() {
    this.promoForm = this.fbuilder.group({
      promoCode: [""],
      promoDetails: [""],
      isActive: [true]
    });
  }
  addStart(promoModal: TemplateRef<any>) {
    this.promoForm.reset();
    this.btnText = "Submit";
    this.modalRef = this.modalService.show(promoModal);
    this.submitted = false;
  }
  editStart(promoModal: TemplateRef<any>, id: number) {
    this.promoService.getPromoById(id).subscribe(res => {
      this.promoForm.patchValue(res);
      this.idForUpdate = id;
      this.btnText = "Save Change";
      this.modalRef = this.modalService.show(promoModal);
    });
  }

  deleteStart(deleteConfirmation: TemplateRef<any>, id: number) {
    this.idForDelete = id;
    this.modalRef = this.modalService.show(deleteConfirmation, {
      class: "modal-sm"
    });
  }

  confirmDelete(): void {
    if (this.idForDelete != null) {
      this.promoService.softDelete(this.idForDelete).subscribe(res => {
        this.loadPromo("active");
        this.modalRef.hide();
        this.idForDelete = null;
        this.promoForm.reset();
        this.toastService.success("Delete Successfully!");
      });
    }
  }
  decline(): void {
    this.message = "Declined!";
    this.modalRef.hide();
  }
  submit() {
    this.submitted = true;
    if (this.promoForm.invalid) {
      this.toastService.error("Enter valid data!");
      return;
    } else {
      if (this.idForUpdate == null) {
        this.promoService.createPromo(this.promoForm.value).subscribe(res => {
          this.loadPromo("active");
          this.modalRef.hide();
          this.promoForm.reset();
          this.toastService.success("Create Successfully!");
        });
      } else {
        this.promoService
          .updatePromo(this.idForUpdate, this.promoForm.value)
          .subscribe(res => {
            this.loadPromo("active");
            this.idForUpdate = null;
            this.modalRef.hide();
            this.promoForm.reset();
            this.toastService.success("Update Successfully!");
          });
      }
    }
  }

  loadPromo(type: string) {
    if (type === "active") {
      this.allPromo = this.promoService.getPromo();
    } else {
      this.allPromo = this.promoService.getArchivePromo();
    }
    console.log(this.allPromo)
  }

  loadArchivedData() {
    this.loadPromo("archive");
  }
}



  
 

 

 

