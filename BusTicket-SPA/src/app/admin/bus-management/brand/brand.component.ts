import { Component, OnInit, TemplateRef } from "@angular/core";
import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder
} from "@angular/forms";
import { BsModalService, BsModalRef } from "ngx-bootstrap/modal";
import { BrandService } from "src/app/_services/brand-service.service";
import { IBrand } from "src/app/models/IBrand";
import { Observable } from "rxjs";
import { ToastrService } from "ngx-toastr";

@Component({
  templateUrl: "./brand.component.html",
  styleUrls: ["./brand.component.css"]
})
export class BrandComponent implements OnInit {
  allBrand: Observable<IBrand[]>;
  submitted = false;
  idForUpdate = null;
  idForDelete = null;
  btnText = "";
  brandForm: FormGroup;
  modalRef: BsModalRef;
  message: string;
  config: any;
  key: string = "name";
  p: number = 1;
  row: number = 2;
  reverse: boolean = false;
  buttonLogic = { archiveData: null, deleteButton: null };

  constructor(
    private modalService: BsModalService,
    private fbuilder: FormBuilder,
    private brandService: BrandService,
    private toastService: ToastrService
  ) {}
  ngOnInit() {
    this.loadActiveBrand();
    this.createForm();
  }

  sort(key) {
    this.key = key;
    this.reverse = !this.reverse;
  }

  createForm() {
    this.brandForm = this.fbuilder.group({
      name: [""],
      isActive: [true]
    });
  }

  addStart(brandModal: TemplateRef<any>) {
    this.brandForm.reset();
    this.btnText = "Submit";
    this.modalRef = this.modalService.show(brandModal);
    this.submitted = false;
  }

  editStart(brandModal: TemplateRef<any>, id: number) {
    this.brandService.getBrandById(id).subscribe(res => {
      this.brandForm.patchValue(res);
      this.idForUpdate = id;
      this.btnText = "Save Change";
      this.modalRef = this.modalService.show(brandModal);
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
      this.brandService.softDelete(this.idForDelete).subscribe(res => {
        this.loadActiveBrand();
        this.modalRef.hide();
        this.idForDelete = null;
        this.brandForm.reset();
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
    if (this.brandForm.invalid) {
      this.toastService.error("Enter valid data!");
      return;
    } else {
      if (this.idForUpdate == null) {
        this.brandService.createBrand(this.brandForm.value).subscribe(res => {
          this.loadActiveBrand();
          this.modalRef.hide();
          this.brandForm.reset();
          this.toastService.success("Create Successfully!");
        });
      } else {
        this.brandService
          .updateBrand(this.idForUpdate, this.brandForm.value)
          .subscribe(res => {
            this.loadActiveBrand();
            this.idForUpdate = null;
            this.modalRef.hide();
            this.brandForm.reset();
            this.toastService.success("Update Successfully!");
          });
      }
    }
  }

  loadActiveBrand() {
    this.allBrand = this.brandService.getBrands();
    this.buttonLogic.archiveData = true;
  }

  loadArchiveBrand() {
    this.allBrand = this.brandService.getArchiveBrands();
    this.buttonLogic.archiveData = false;
  }
}
