import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder
} from "@angular/forms";
import { VendorService } from "src/app/_services/vendor.service";
import { IVendor } from "src/app/models/IVendor";
import { Observable } from "rxjs";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: 'app-vendor',
  templateUrl: './vendor.component.html',
  styleUrls: ['./vendor.component.css']
})
export class VendorComponent implements OnInit {

  allVendor: Observable<IVendor[]>
  submitted = false;
  idForUpdate = null;
  idForDelete = null;
  btnText = "";
  vendorForm: FormGroup;
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
    private vendorService: VendorService,
    private toastService: ToastrService) { }

  ngOnInit() {
    this.loadVendor("active");
    this.createForm();
  }

  sort(key) {
    this.key = key;
    this.reverse = !this.reverse;
  }

  createForm() {
    this.vendorForm = this.fbuilder.group({
      vendorName: [''],
      vendorPhone:[''],
      vendorEmail: [''],
      vendorAddress: [''],
      isActive: [true]
    });
  }

  addStart(vendorModal: TemplateRef<any>) {
    this.vendorForm.reset();
    this.btnText = "Submit";
    this.modalRef = this.modalService.show(vendorModal);
    this.submitted = false;
  }

  editStart(vendorModal: TemplateRef<any>, id: number) {
    this.vendorService.getVendorById(id).subscribe(res => {
      this.vendorForm.patchValue(res);
      this.idForUpdate = id;
      this.btnText = "Save Change";
      this.modalRef = this.modalService.show(vendorModal);
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
      this.vendorService.softDelete(this.idForDelete).subscribe(res => {
        this.loadVendor("active");
        this.modalRef.hide();
        this.idForDelete = null;
        this.vendorForm.reset();
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
    if (this.vendorForm.invalid) {
      this.toastService.error("Enter valid data!");
      return;
    } else {
      if (this.idForUpdate == null) {
        this.vendorService.createVendor(this.vendorForm.value).subscribe(res => {
          this.loadVendor("active");
          this.modalRef.hide();
          this.vendorForm.reset();
          this.toastService.success("Create Successfully!");
        });
      } else {
        this.vendorService
          .updateVendor(this.idForUpdate, this.vendorForm.value)/*, this.vendorForm.value*/
          .subscribe(res => {
            this.loadVendor("active");
            this.idForUpdate = null;
            this.modalRef.hide();
            this.vendorForm.reset();
            this.toastService.success("Update Successfully!");
          });
      }
    }
  }

  loadVendor(type: string) {
    if (type === "active") {
      this.allVendor = this.vendorService.getVendors();
    } else {
      this.allVendor = this.vendorService.getArchiveVendors();
    }
  }

  loadArchivedData() {
    this.loadVendor("archive");
  }

}
