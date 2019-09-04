import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { FormGroup, FormControl } from "@angular/forms";
import { AuthService } from "src/app/_services/auth.service";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor(private router: Router, private service: AuthService) {}

  ngOnInit() {
    this.loginForm = new FormGroup({
      username: new FormControl(),
      password: new FormControl()
    });
  }
  submit() {
    console.log(this.loginForm.value);
    this.service
      .login(this.loginForm.value)
      .subscribe(res => this.router.navigate(["admin/dashboard"]));
  }
}
