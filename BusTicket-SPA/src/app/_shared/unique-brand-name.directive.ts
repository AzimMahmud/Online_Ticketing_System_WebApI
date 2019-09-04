import { Directive } from "@angular/core";
import {
  AsyncValidator,
  AbstractControl,
  ValidationErrors
} from "@angular/forms";
import { Injectable } from "@angular/core";
import { Http, Response, Headers } from "@angular/http";
import { Observable } from "rxjs";

@Directive({
  selector: "[appUniqueBrandName]",
  providers: []
})
export class UniqueBrandNameDirective implements AsyncValidator {
  validate(
    control: AbstractControl
  ): Promise<ValidationErrors> | Observable<ValidationErrors> {
    throw new Error("Method not implemented.");
  }
  registerOnValidatorChange?(fn: () => void): void {
    throw new Error("Method not implemented.");
  }

  constructor() {}
}
