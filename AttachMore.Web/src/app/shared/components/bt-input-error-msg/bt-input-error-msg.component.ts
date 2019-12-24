import { Component, OnInit, Input } from '@angular/core';
import { AbstractControlDirective, AbstractControl } from '@angular/forms';

@Component({
  selector: 'am-bt-input-error-msg',
  template: `
    <div *ngIf="shouldShowErrors()" class="alert alert-danger r-error">
      <div *ngFor="let error of listOfErrors()">{{error}}</div>
    </div>`
})
export class AmBtInputErrorMsgComponent implements OnInit {
  private static readonly errorMessages = {
    required: params => 'This field is required.',
    minlength: params => `Minimum ${params.requiredLength} characters are required.`,
    tmMinLength: params => `Minimum ${params} characters are required.`,
    maxlength: params => `Maximum ${params.requiredLength} characters are required.`,
    pattern: params => `The field is invalid.`,
    email: params => 'Not a valid email address.',
    confirmEqual: params => `Password and confirm password are not equal.`
  };

  @Input() private control: AbstractControlDirective | AbstractControl;
  @Input() private fieldName = '';

  constructor() { }

  ngOnInit() { }

  shouldShowErrors(): boolean {
    return (
      this.control &&
      this.control.invalid &&
      this.control.errors &&
      (this.control.dirty || this.control.touched)
    );
  }

  listOfErrors(): string[] {
    return Object.keys(this.control.errors).map(field =>
      this.getMessage(field, this.control.errors[field])
    );
  }

  private getMessage(type: string, params: any) {
    return AmBtInputErrorMsgComponent.errorMessages[type](params);
  }
}
