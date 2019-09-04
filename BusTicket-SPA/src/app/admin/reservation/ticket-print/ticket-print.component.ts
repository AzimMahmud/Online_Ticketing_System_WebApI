import { Component, OnInit } from '@angular/core';
import { document } from 'ngx-bootstrap';

@Component({
  selector: 'app-ticket-print',
  templateUrl: './ticket-print.component.html',
  styleUrls: ['./ticket-print.component.css']
})
export class TicketPrintComponent implements OnInit {
  
  constructor() { }

  ngOnInit() {
  }
  printTKT(divName) {
    var printContents = document.getElementById(divName).innerHTML;
    var orginalContents = document.body.innerHTML;

    document.body.innerHTML = printContents;

    window.print();


    document.body.innerHTML = orginalContents;
    
  }




}
