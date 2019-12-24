import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material';

import { SignupComponent } from '../signup/signup.component';
import { AuthService } from '../../../../services/auth.service';
import { ForgetPasswordComponent } from '../../auth/forget-password/forget-password.component';

@Component({
  selector: 'am-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss']
})
export class SigninComponent implements OnInit {

  signinForm: FormGroup;

  /**
   * @description Get email Form Control
   * @returns FormControl
   */
  get email(): FormControl {
    return this.signinForm.get('email') as FormControl;
  }

  /**
   * @description Get password Form Control
   * @returns FormControl
   */
  get password(): FormControl {
    return this.signinForm.get('password') as FormControl;
  }

  constructor(private dialog: MatDialog,
    private dialogRef: MatDialogRef<SigninComponent>,
    private authService: AuthService ) { }

  ngOnInit() {
    this.initalizeForm();
  }

  /**
  * @description Intialize Form
  */
  initalizeForm(): void {
    this.signinForm = new FormGroup({
      email: new FormControl(null, [
        Validators.required,
        Validators.email
      ]),
      password: new FormControl(null, [
        Validators.required,
        Validators.maxLength(10),
        Validators.minLength(6)
      ]),
      rememberMe: new FormControl(false)
    });
  }

  /**
   * @description Fire When form is submitted
   */
  onSubmit(): void {
    if (this.signinForm.invalid) {
      return;
    }
    this.authService.signinUser(this.signinForm.value).subscribe(res => {
      this.dialogRef.close(res);
    });
  }

  /**
   * --opens signup form
   */
  openSignupForm() {
    const dialogRef = this.dialog.open(SignupComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
      }
    });
  }

   /**
   * -- opens forget password form
   */
  forgetPasswordForm() {
    const dialogRef = this.dialog.open(ForgetPasswordComponent, {
      data: this.email.value
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
      }
    });
  }
}
