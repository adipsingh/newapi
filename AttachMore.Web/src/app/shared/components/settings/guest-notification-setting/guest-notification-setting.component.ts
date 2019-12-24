import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormArray, FormControl } from '@angular/forms';
import { Common } from '../../../../configuration';

import { MESSAGES } from '../../../../configuration/success.msg';
import { SettingsService } from '../../../../services/settings.service';
import { UploadService } from '../../../../services/upload.service';
import { NotificationService } from '../../../../services/notification.service';
import { GuestNotificationSettings } from '../../../../models/guest-notification-settings.model';

@Component({
  selector: 'am-guest-notification-setting',
  templateUrl: './guest-notification-setting.component.html',
  styleUrls: ['./guest-notification-setting.component.scss']
})
export class GuestNotificationSettingComponent implements OnInit {

  guestNotificationSettingForm: FormGroup;
  config = Common;
  @Input() settings: GuestNotificationSettings;

  get notifyInfoArray() {
    return this.guestNotificationSettingForm.get('notifyInfo') as FormArray;
  }

  constructor(private settingsService: SettingsService,
    private uploadService: UploadService,
    private notificationService: NotificationService) { }

  ngOnInit() {
    this.initalizeForm();
  }

  ngAfterViewInit() {
    this.intializeFormValue();
  }

  intializeFormValue() {
    if (!this.guestNotificationSettingForm) {
      return;
    }
    this.guestNotificationSettingForm.setValue({      
      fillEmail: this.settings.fillEmail,
      fillName: this.settings.fillName,
      fillCompany: this.settings.fillCompany,      
      fillPhone: this.settings.fillPhone,
      fillPassword: this.settings.fillPassword,
      downloadPassword: this.settings.downloadPassword
    });
  }

  /**
  * @description Intialize Form
  */
  initalizeForm(): void {
    this.guestNotificationSettingForm = new FormGroup({
      fillPhone: new FormControl(),
      fillCompany: new FormControl(),
      fillPassword: new FormControl(),
      fillEmail: new FormControl(),
      fillName: new FormControl(),
      downloadPassword: new FormControl(),
    });
  }

  


  onSubmit() {
    const JSON_DATA: GuestNotificationSettings = {
      ...this.guestNotificationSettingForm.value,
      attachmentId: this.uploadService.attachmentId
    };

    //this.settingsService.notificationSettings(JSON_DATA).subscribe(res => {
    //  this.notificationService.notify(MESSAGES.notificationSettings);
    //});
  }

  /**
   * Remove item from Notify info from Array
   */
  removeItemFromNotifyInfoArray(index: number) {
    this.notifyInfoArray.removeAt(index);
  }

}
