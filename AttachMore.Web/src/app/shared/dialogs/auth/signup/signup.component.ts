import { Component, OnInit, Inject, Optional } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { AuthService } from '../../../../services/auth.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { DialogService } from '../../../../services/dialog.service';

@Component({
  selector: 'am-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

  signupForm: FormGroup;

  /**
 * @description Get firstName Form Control
 * @returns FormControl
 */
  get firstName(): FormControl {
    return this.signupForm.get('firstName') as FormControl;
  }

  /**
 * @description Get lastName Form Control
 * @returns FormControl
 */
  get lastName(): FormControl {
    return this.signupForm.get('lastName') as FormControl;
  }

  /**
   * @description Get email Form Control
   * @returns FormControl
   */
  get email(): FormControl {
    return this.signupForm.get('email') as FormControl;
  }

  /**
   * @description Get password Form Control
   * @returns FormControl
   */
  get password(): FormControl {
    return this.signupForm.get('password') as FormControl;
  }

  constructor(private authService: AuthService,
    private dialogRef: MatDialogRef<SignupComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) public userEmail: string,   private dialogService: DialogService) {
      }

  ngOnInit() {
    this.initalizeForm();
  }

  /**
  * @description Intialize Form
  */
  initalizeForm(): void {
    this.signupForm = new FormGroup({
      firstName: new FormControl(null, [
        Validators.required
      ]),
      lastName: new FormControl(null, [
        Validators.required
      ]),
      email: new FormControl(this.userEmail, [
        Validators.required,
        Validators.email
      ]),
      password: new FormControl(null, [
        Validators.required,
        Validators.maxLength(10),
        Validators.minLength(6)
      ]),
      company: new FormControl(null),
      phoneNumber: new FormControl(null)
    });
  }

  /**
   * @description Fire When form is submitted
   */
  onSubmit(): void {
    if (this.signupForm.invalid) {
      return;
    }
    const JSON_DATA = {
      ...this.signupForm.value,
      confirmPassword: this.signupForm.value.password
    };
    this.authService.registerUser(JSON_DATA).subscribe(result => {

      if (result) {
        this.dialogRef.close(result);
        this.dialogService.planAndPricingDialog().subscribe(res => {
            if (res) {
            }
            this.dialogService.welcomeDialog();
        });
    }
    });
  }
}
