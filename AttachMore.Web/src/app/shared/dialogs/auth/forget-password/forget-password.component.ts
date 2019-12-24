import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { AuthService } from '../../../../services/auth.service';
import { NotificationService } from '../../../../services/notification.service';
import { MESSAGES } from '../../../../configuration/success.msg';

@Component({
  selector: 'am-forget-password',
  templateUrl: './forget-password.component.html',
  styleUrls: ['./forget-password.component.scss']
})
export class ForgetPasswordComponent implements OnInit {

  forgetPasswordForm: FormGroup;

  /**
   * @description Get email Form Control
   * @returns FormControl
   */
  get email(): FormControl {
    return this.forgetPasswordForm.get('email') as FormControl;
  }

  constructor(
    private dialogRef: MatDialogRef<ForgetPasswordComponent>,
    @Inject(MAT_DIALOG_DATA) public receivedEmail: string,
    private authService: AuthService,
    private notificationService: NotificationService) { }

  ngOnInit() {
    this.initalizeForm();
  }

  /**
  * @description Intialize Form
  */
  initalizeForm(): void {
    this.forgetPasswordForm = new FormGroup({
      email: new FormControl(this.receivedEmail, [
        Validators.required,
        Validators.email
      ])
    });
  }

  /**
   * @description Fire When form is submitted
   */
  onSubmit(): void {
    if (this.forgetPasswordForm.invalid) {
      return;
    }
    this.authService.forgetPassword(this.email.value).subscribe(res => {
      this.notificationService.notify(MESSAGES.forgetPassword);
      this.dialogRef.close(true);
    });
  }

}
