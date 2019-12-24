import { Component, ViewChild, Input, AfterViewInit} from '@angular/core';
import { NgForm } from '@angular/forms';

import { SettingsService } from '../../../../services/settings.service';
import { UploadService } from '../../../../services/upload.service';
import { SecuritySettings } from '../../../../models';
import { NotificationService } from '../../../../services/notification.service';
import { MESSAGES } from '../../../../configuration/success.msg';

@Component({
  selector: 'am-security-setting',
  templateUrl: './security-setting.component.html',
  styleUrls: ['./security-setting.component.scss']
})
export class SecuritySettingComponent implements AfterViewInit {

  showEmailDetails = false;
  showEmail = false;
  showPasswordDetails = false;
  emailType = 'ANY';
  @Input() settings: SecuritySettings;

  @ViewChild('securitySettingForm') securitySettingForm: NgForm;

  constructor(private settingsService: SettingsService,
    private uploadService: UploadService,
    private notificationService: NotificationService) { }

  ngAfterViewInit() {
    // this.intializeFormValue();
    this.showEmailDetails = !!this.settings.accessEmail;
  }

  // intializeFormValue() {
  //   if (!this.securitySettingForm) {
  //     return;
  //   }
  //   this.securitySettingForm.setValue({
  //     emailType: !!this.settings.accessEmail,
  //     accessEmail: this.settings.accessEmail,
  //     accessPassword: this.settings.accessPassword
  //   });
  // }

  onSubmit() {
    const JSON_DATA: SecuritySettings = {
      accessEmail: (this.securitySettingForm.controls['accessEmail'] && this.securitySettingForm.controls['accessEmail'].valid)
       ? this.securitySettingForm.value.accessEmail : '',
      accessPassword: this.securitySettingForm.value.accessPassword,
      attachmentId: this.uploadService.attachmentId,
      accessName: '',
      accessCompany: '',
      accessContactNumber: '',
      accessPayment: 12.2
    };

    this.settingsService.securitySettings(JSON_DATA).subscribe(res => {
      this.notificationService.notify(MESSAGES.securitySettings);
    });
  }

}
