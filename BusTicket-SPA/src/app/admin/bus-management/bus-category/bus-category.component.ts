import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder
} from "@angular/forms";
import { BusCategoryService } from "src/app/_services/bus-category.service";
import { IBusCategory } from "src/app/models/IBusCategory";
import { Observable } from "rxjs";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: 'app-bus-category',
  templateUrl: './bus-category.component.html',
  styleUrls: ['./bus-category.component.css']
})
export class BusCategoryComponent implements OnInit {

  allBusCategory: Observable<IBusCategory[]>;
  submitted = false;
  idForUpdate = null;
  idForDelete = null;
  btnText = "";
  busCategoryForm: FormGroup;
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
    private busCategoryService: BusCategoryService,
    private toastService: ToastrService
  ) { }
  ngOnInit() {
    this.loadBusCategory("active");
    this.createForm();
  }

  sort(key) {
    this.key = key;
    this.reverse = !this.reverse;
  }

  createForm() {
    this.busCategoryForm = this.fbuilder.group({
      name: [""],
      isActive: [true]
    });
  }

  addStart(busCategoryModal: TemplateRef<any>) {
    this.busCategoryForm.reset();
    this.btnText = "Submit";
    this.modalRef = this.modalService.show(busCategoryModal);
    this.submitted = false;
  }

  editStart(busCategoryModal: TemplateRef<any>, id: number) {
    this.busCategoryService.getBusCategoryById(id).subscribe(res => {
      this.busCategoryForm.patchValue(res);
      this.idForUpdate = id;
      this.btnText = "Save Change";
      this.modalRef = this.modalService.show(busCategoryModal);
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
      this.busCategoryService.deleteBusCategory(this.idForDelete).subscribe(res => {
        this.loadBusCategory("active");
        this.modalRef.hide();
        this.idForDelete = null;
        this.busCategoryForm.reset();
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
    if (this.busCategoryForm.invalid) {
      this.toastService.error("Enter valid data!");
      return;
    } else {
      if (this.idForUpdate == null) {
        this.busCategoryService.createBusCategory(this.busCategoryForm.value).subscribe(res => {
          this.loadBusCategory("active");
          this.modalRef.hide();
          this.busCategoryForm.reset();
          this.toastService.success("Create Successfully!");
        });
      } else {
        this.busCategoryService
          .updateBusCategory(this.idForUpdate, this.busCategoryForm.value)
          .subscribe(res => {
            this.loadBusCategory("active");
            this.idForUpdate = null;
            this.modalRef.hide();
            this.busCategoryForm.reset();
            this.toastService.success("Update Successfully!");
          });
      }
    }
  }

  loadBusCategory(type: string) {
    if (type === "active") {
      this.allBusCategory = this.busCategoryService.getBusCategory();
    } else {
      this.allBusCategory = this.busCategoryService.getArchiveBusCategory();
    }
  }

  loadArchivedData() {
    this.loadBusCategory("archive");
  }

}
