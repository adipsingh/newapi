import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { AccountService } from '../../../services/account.service';
import { NotificationService } from '../../../services/notification.service';
import { MESSAGES } from '../../../configuration/success.msg';

@Component({
  selector: 'am-password-form',
  templateUrl: './password-form.component.html',
  styleUrls: ['./password-form.component.scss']
})
export class PasswordFormComponent implements OnInit {

  passwordForm: FormGroup;

  @Input() type: string;

  /**
 * @description newPassword Form Control
 * @returns FormControl
 */
  get newPassword(): FormControl {
    return this.passwordForm.get('newPassword') as FormControl;
  }

  /**
 * @description confirmPassword Form Control
 * @returns FormControl
 */
  get confirmPassword(): FormControl {
    return this.passwordForm.get('confirmPassword') as FormControl;
  }

  constructor(private accountService: AccountService,
    private notificationService: NotificationService) { }

  ngOnInit() {
    this.initalizeForm();
  }

  /**
  * @description Intialize Form
  */
  initalizeForm(): void {
    this.passwordForm = new FormGroup({
      newPassword: new FormControl(null, [
        Validators.required,
        Validators.maxLength(10),
        Validators.minLength(6)
      ]),
      confirmPassword: new FormControl(null, [
        Validators.required,
        Validators.maxLength(10),
        Validators.minLength(6)
      ])
    });
  }

  /**
   * on Submit change password
   */
  onSubmit() {
    if (this.passwordForm.invalid) {
      return;
    }

    const JSON_DATA = {
      ...this.passwordForm.value
    };
    this.accountService.resetPassword(this.type, JSON_DATA).subscribe(res => {
      this.passwordForm.reset();
      if (this.type === 'RESET') {
        this.notificationService.notify(MESSAGES.resetPassword);
      } else {
        this.notificationService.notify(MESSAGES.changePassword);
      }
    });
  }
}
