import { Component, OnInit, TemplateRef } from "@angular/core";
import { BsModalService, BsModalRef } from "ngx-bootstrap/modal";
import { Observable } from "rxjs";
import {
  FormGroup,
  FormBuilder,
  Validators,
  FormControl
} from "@angular/forms";

import { ToastrService } from "ngx-toastr";

import { RouteService } from "src/app/_services/route.service";
import { IRoutesDetails } from "src/app/models/IRoutesDetails";
import { IBusRoute } from "src/app/models/IBusRoute";
import { Cities, CityList } from "src/app/_shared/Cities";
import { startWith, map } from "rxjs/operators";

@Component({
  selector: "app-routedetails",
  templateUrl: "./routedetails.component.html",
  styleUrls: ["./routedetails.component.css"]
})
export class RoutedetailsComponent implements OnInit {
  board: string[] = [
    "Barguna",
    "Barisal",
    "Bhola",
    "Jhalokati",
    "Patuakhali",
    "Pirojpur ",
    "Bandarban",
    "Brahmanbaria",
    "Chandpur",
    "Chittagong",
    "Comilla",
    "Cox's Bazar",
    "Feni",
    "Khagrachhari",
    "Lakshmipur",
    "Noakhali",
    "Rangamati",
    "Dhaka",
    "Faridpur",
    "Gazipur",
    "Gopalganj",
    "Jamalpur",
    "Kishoreganj",
    "Madaripur",
    "Manikganj",
    "Munshiganj",
    "Mymensingh",
    "Narayanganj",
    "Narsingdi",
    "Netrakona",
    "Rajbari",
    "Shariatpur",
    "Sherpur",
    "Tangail",
    "Bagerhat",
    "Chuadanga",
    "Jessore",
    "Jhenaidah",
    "Khulna",
    "Kushtia",
    "Magura",
    "Meherpur",
    "Narail",
    "Satkhira",
    "Bogra",
    "Joypurhat",
    "Naogaon",
    "Natore ",
    "Nawabganj",
    "Pabna",
    "Rajshahi",
    "Sirajganj",
    "Dinajpur",
    "Gaibandha",
    "Kurigram",
    "Lalmonirhat",
    "Nilphamari",
    "Panchagarh",
    "Rangpur",
    "Thakurgaon",
    "Habiganj",
    "Moulvibazar",
    "Sunamganj",
    "Sylhet"
  ];

  drop: string[] = [
    "Barguna",
    "Barisal",
    "Bhola",
    "Jhalokati",
    "Patuakhali",
    "Pirojpur ",
    "Bandarban",
    "Brahmanbaria",
    "Chandpur",
    "Chittagong",
    "Comilla",
    "Cox's Bazar",
    "Feni",
    "Khagrachhari",
    "Lakshmipur",
    "Noakhali",
    "Rangamati",
    "Dhaka",
    "Faridpur",
    "Gazipur",
    "Gopalganj",
    "Jamalpur",
    "Kishoreganj",
    "Madaripur",
    "Manikganj",
    "Munshiganj",
    "Mymensingh",
    "Narayanganj",
    "Narsingdi",
    "Netrakona",
    "Rajbari",
    "Shariatpur",
    "Sherpur",
    "Tangail",
    "Bagerhat",
    "Chuadanga",
    "Jessore",
    "Jhenaidah",
    "Khulna",
    "Kushtia",
    "Magura",
    "Meherpur",
    "Narail",
    "Satkhira",
    "Bogra",
    "Joypurhat",
    "Naogaon",
    "Natore ",
    "Nawabganj",
    "Pabna",
    "Rajshahi",
    "Sirajganj",
    "Dinajpur",
    "Gaibandha",
    "Kurigram",
    "Lalmonirhat",
    "Nilphamari",
    "Panchagarh",
    "Rangpur",
    "Thakurgaon",
    "Habiganj",
    "Moulvibazar",
    "Sunamganj",
    "Sylhet"
  ];
  filteredBoardOptions: Observable<string[]>;
  filteredDropOptions: Observable<string[]>;
  showAutocomplete: boolean;

  isMeridian = false;
  showSpinners = true;
  allRoute: Observable<IBusRoute[]>;
  submitted = false;
  idForUpdate = null;
  idForDelete = null;
  btnText = "";
  busDetails: any[];
  routeForm: FormGroup;
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
    private routeService: RouteService,
    private toastService: ToastrService
  ) {}

  ngOnInit() {
    this.loadActiveRoute();
    this.createForm();
    this.getBusDetails();

    this.loadBoardPoint();
    this.loadDropPoint();
  }
  loadBoardPoint() {
    this.filteredBoardOptions = this.routeForm
      .get("boardPoint")
      .valueChanges.pipe(
        startWith(""),
        map(value => this._filterBoard(value))
      );
  }

  loadDropPoint() {
    this.filteredDropOptions = this.routeForm
      .get("dropPoint")
      .valueChanges.pipe(
        startWith(""),
        map(value => this._filterDrop(value))
      );
  }

  private _filterBoard(value: string): string[] {
    const filterValue = value.toLowerCase();
    return this.board.filter(option =>
      option.toLowerCase().includes(filterValue)
    );
  }

  private _filterDrop(value: string): string[] {
    const filterValue = value.toLowerCase();
    return this.drop.filter(option =>
      option.toLowerCase().includes(filterValue)
    );
  }
  updatedVal(e) {
    if (e && e.length >= 1) {
      this.showAutocomplete = true;
    } else {
      this.showAutocomplete = false;
    }
  }

  sort(key) {
    this.key = key;
    this.reverse = !this.reverse;
  }

  createForm() {
    this.routeForm = this.fbuilder.group({
      busDetailID: [0],
      fare: [""],
      boardPoint: [""],
      dropPoint: [""],
      boardTime: [""],
      dropTime: [""],
      isActive: [true]
    });
  }

  getBusDetails() {
    this.routeService.getBusDetails().subscribe(res => {
      console.log(res);
      this.busDetails = res;
    });
  }

  addStart(routeModal: TemplateRef<any>) {
    this.routeForm.reset();
    this.btnText = "Submit";
    this.modalRef = this.modalService.show(
      routeModal,
      Object.assign({}, { class: "gray modal-lg" })
    );
    this.submitted = false;
  }

  editStart(routeModal: TemplateRef<any>, id: number) {
    this.routeService.getRoutesById(id).subscribe(res => {
      this.routeForm.patchValue(res);
      this.idForUpdate = id;
      this.btnText = "Save Change";
      this.modalRef = this.modalService.show(
        routeModal,
        Object.assign({}, { class: "gray modal-lg" })
      );
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
      this.routeService.deleteRoute(this.idForDelete).subscribe(res => {
        this.loadActiveRoute();
        this.modalRef.hide();
        this.idForDelete = null;
        this.routeForm.reset();
        this.toastService.success("Delete Successfully!");
      });
    }
  }

  decline(): void {
    this.message = "Declined!";
    this.modalRef.hide();
  }

  submit() {
    console.log(this.routeForm.value);
    console.log(this.routeForm.value);
    this.submitted = true;
    if (this.routeForm.invalid) {
      this.toastService.error("Enter valid data!");
      return;
    } else {
      if (this.idForUpdate == null) {
        this.routeService.createRoute(this.routeForm.value).subscribe(res => {
          this.loadActiveRoute();
          this.modalRef.hide();
          this.routeForm.reset();
          this.toastService.success("Create Successfully!");
        });
      } else {
        this.routeService.updateRoute(this.routeForm.value).subscribe(res => {
          this.loadActiveRoute();
          this.idForUpdate = null;
          this.modalRef.hide();
          this.routeForm.reset();
          this.toastService.success("Update Successfully!");
        });
      }
    }
  }

  loadActiveRoute() {
    this.allRoute = this.routeService.getRoutes();
    this.buttonLogic.archiveData = true;
  }

  loadArchivedData() {
    this.allRoute = this.routeService.getArchiveData();
    this.buttonLogic.archiveData = false;
  }
}
