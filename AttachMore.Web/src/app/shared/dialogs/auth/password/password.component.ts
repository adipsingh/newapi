import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material';

import { AuthService } from '../../../../services/auth.service';
import { Signin } from 'src/app/models';
import { AuthDialogService } from 'src/app/services/auth-dialog.service';
import { ForgetPasswordComponent } from '../forget-password/forget-password.component';

@Component({
  selector: 'am-password',
  templateUrl: './password.component.html',
  styleUrls: ['./password.component.scss']
})
export class PasswordComponent implements OnInit {

  passwordForm: FormGroup;

  get password(): FormControl {
    return this.passwordForm.get('password') as FormControl;
  }

  constructor(private authService: AuthService,
    private dialogRef: MatDialogRef<PasswordComponent>,
    private matDialog: MatDialog,
    @Inject(MAT_DIALOG_DATA) public email: string) { }

  ngOnInit() {
    this.initalizeForm();
  }

  /**
  * @description Intialize Form
  */
  initalizeForm(): void {
    this.passwordForm = new FormGroup({
      password: new FormControl(null, [
        Validators.required,
        Validators.maxLength(10),
        Validators.minLength(6)
      ])
    });
  }

  /**
   * @description Fire When form is submitted
   */
  onSubmit(): void {
    if (this.passwordForm.invalid) {
      return;
    }
    const JSON_DATA: Signin = {
      ...this.passwordForm.value,
      email: this.email,
      rememberMe: false
    };

    this.authService.signinUser(JSON_DATA).subscribe(res => {
      this.dialogRef.close(res);
    });
  }

  /**
   * Open forget password form
   */
  forgetPasswordForm() {
    this.dialogRef.close(false);
    const dialogRef = this.matDialog.open(ForgetPasswordComponent, {
      data: this.email
    });

    dialogRef.afterClosed().subscribe(result => {
    });
  }
}
