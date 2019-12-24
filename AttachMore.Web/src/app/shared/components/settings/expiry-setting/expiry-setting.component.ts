import { Component, OnInit, Input, AfterViewInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { SettingsService } from '../../../../services/settings.service';
import { ExpirySettings } from '../../../../models';
import { UploadService } from '../../../../services/upload.service';
import { NotificationService } from '../../../../services/notification.service';
import { MESSAGES } from '../../../../configuration/success.msg';

@Component({
  selector: 'am-expiry-setting',
  templateUrl: './expiry-setting.component.html',
  styleUrls: ['./expiry-setting.component.scss']
})
export class ExpirySettingComponent implements OnInit, AfterViewInit {

  minDate = new Date();
  expirySettingForm: FormGroup;
  @Input() settings: ExpirySettings;

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
    if (!this.expirySettingForm) {
      return;
    }
    this.expirySettingForm.setValue({
      downloadsLimit: this.settings.downloadsLimit.toString(),
      expiryDate: new Date(this.settings.expiryDate),
      deletionDate: new Date(this.settings.deletionDate),
    });
  }

  /**
  * @description Intialize Form
  */
  initalizeForm(): void {
    this.expirySettingForm = new FormGroup({
      downloadsLimit: new FormControl(5),
      expiryDate: new FormControl(),
      deletionDate: new FormControl()
    });
  }

  onSubmit() {
    const JSON_DATA: ExpirySettings = {
      deletionDate: this.expirySettingForm.value.deletionDate,
      expiryDate: this.expirySettingForm.value.expiryDate,
      downloadsLimit: this.expirySettingForm.value.downloadsLimit,
      attachmentId: this.uploadService.attachmentId
    };

    this.settingsService.expirySettings(JSON_DATA).subscribe(res => {
      this.notificationService.notify(MESSAGES.expirySettings);
    });
  }

}
