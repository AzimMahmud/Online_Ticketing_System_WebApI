import { Component, OnInit, TemplateRef } from "@angular/core";
import { BsModalService, BsModalRef } from "ngx-bootstrap/modal";
import { Observable } from "rxjs";
import { IBrand } from "src/app/models/IBrand";
import { FormGroup, FormBuilder } from "@angular/forms";
import { IBusDetails } from "src/app/models/IBusDetails";
import { BusDetailsService } from "src/app/_services/busDetails.service";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: "app-bus-details",
  templateUrl: "./bus-details.component.html",
  styleUrls: ["./bus-details.component.css"]
})
export class BusDetailsComponent implements OnInit {
  allBusDetails: Observable<any>;
  submitted = false;
  idForUpdate = null;
  idForDelete = null;
  btnText = "";
  busDetailForm: FormGroup;
  modalRef: BsModalRef;
  message: string;
  config: any;
  key: string = "name";
  p: number = 1;
  row: number = 2;
  reverse: boolean = false;

  allBrand: any;
  allCategory: any;
  allVendor: any;
  constructor(
    private modalService: BsModalService,
    private fbuilder: FormBuilder,
    private busDetailsService: BusDetailsService,
    private toastService: ToastrService
  ) {}

  ngOnInit() {
    this.loadBusDetails("active");
    this.createForm();
    this.loadSelectOptions();
  }

  loadBusDetails(type: string) {
    if (type === "active") {
      this.busDetailsService.getBusDetails().subscribe(res => {
        console.log(res);
        this.allBusDetails = res;
      });
    } else {
      this.busDetailsService.getArchiveBusDetails().subscribe(res => {
        this.allBusDetails = res;
      });
    }
  }

  loadSelectOptions() {
    this.busDetailsService.getBrandDetailsSelectOption().subscribe(res => {
      this.allBrand = res;
    });
    this.busDetailsService.getCategoryDetailsSelectOption().subscribe(res => {
      this.allCategory = res;
    });
    this.busDetailsService.getVendorDetailsSelectOption().subscribe(res => {
      this.allVendor = res;
      console.log(res);
    });
  }
  loadArchivedData() {
    this.loadBusDetails("archive");
  }

  sort(key) {
    this.key = key;
    this.reverse = !this.reverse;
  }

  createForm() {
    this.busDetailForm = this.fbuilder.group({
      brandID: [0],
      busCategoryID: [0],
      vendorID: [0],
      isActive: [true]
    });
  }

  addStart(busDetailsModal: TemplateRef<any>) {
    this.busDetailForm.reset();
    this.btnText = "Submit";
    this.modalRef = this.modalService.show(busDetailsModal);
    this.submitted = false;
  }

  editStart(brandModal: TemplateRef<any>, id: number) {
    this.busDetailsService.getBusDetailById(id).subscribe(res => {
      this.busDetailForm.patchValue(res);
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
      this.busDetailsService.softDelete(this.idForDelete).subscribe(res => {
        this.loadBusDetails("active");
        this.modalRef.hide();
        this.idForDelete = null;
        this.busDetailForm.reset();
        this.toastService.success("Delete Successfully!");
      });
    }
  }

  decline(): void {
    this.message = "Declined!";
    this.modalRef.hide();
  }

  submit() {
    console.log(this.busDetailForm.value);
    this.submitted = true;
    if (this.busDetailForm.invalid) {
      this.toastService.error("Enter valid data!");
      return;
    } else {
      if (this.idForUpdate == null) {
        this.busDetailsService
          .createBusDetail(this.busDetailForm.value)
          .subscribe(res => {
            this.loadBusDetails("active");
            this.modalRef.hide();
            this.busDetailForm.reset();
            this.toastService.success("Create Successfully!");
          });
      } else {
        this.busDetailsService
          .updateBusDetail(this.idForUpdate, this.busDetailForm.value)
          .subscribe(res => {
            this.loadBusDetails("active");
            this.idForUpdate = null;
            this.modalRef.hide();
            this.busDetailForm.reset();
            this.toastService.success("Update Successfully!");
          });
      }
    }
  }
}
