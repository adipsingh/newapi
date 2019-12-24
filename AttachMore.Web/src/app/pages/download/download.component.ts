import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { saveAs } from 'file-saver';

import { AttachmentService } from '../../services/attachment.service';
import { DownloadAttachment, SecuritySettings } from '../../models';
import { DialogService } from '../../services/dialog.service';
import { SettingsService } from '../../services/settings.service';

@Component({
  selector: 'am-download',
  templateUrl: './download.component.html',
  styleUrls: ['./download.component.scss']
})
export class DownloadComponent implements OnInit {

  attachmentId = 0;
  securitySettings: SecuritySettings = <SecuritySettings>{};

  constructor(private route: ActivatedRoute,
    public dialogService: DialogService,
    private attachmentService: AttachmentService,
    private settingService: SettingsService) { }

  ngOnInit() {
    this.route.params.subscribe((res: Params) => {
      this.attachmentId = res.attachmentId;
      this.getSecuritySettings();
    });
  }

  /**
   * Get Secuirty Settings
   */
  getSecuritySettings() {
    this.settingService.getSecuritySettings(this.attachmentId).subscribe(res => {
      this.securitySettings = res;
    });
  }

  /**
   * Download file when button clicked
   */
  whenDownloadClicked() {
    if (this.securitySettings.accessEmail || this.securitySettings.accessPassword) {
      this.dialogService.downloadAttachmentDialog(this.securitySettings).subscribe(res => {
        if (res) {
          this.downloadAttachment(res);
        }
      });
    } else {
      this.downloadAttachment({accessEmail: '', password: ''} as DownloadAttachment);
    }
  }

  /**
   * Download Attachment
   * @param downloadAttachmentDetails
   */
  downloadAttachment(downloadAttachmentDetails: DownloadAttachment) {
    const JSON_DATA: DownloadAttachment = {
      attachmentId: this.attachmentId,
      ...downloadAttachmentDetails
    };

    this.attachmentService.downloadAttachment(JSON_DATA).subscribe((res) => {
      if (this.attachmentService.attachment.fileDetails && this.attachmentService.attachment.fileDetails.length) {
        if (this.attachmentService.attachment.fileDetails.length > 1) {
          saveAs(res, `${this.attachmentService.attachment.attachmentName}.zip`);
        } else {
          saveAs(res, `${this.attachmentService.attachment.attachmentName}.${this.attachmentService.attachment.fileDetails[0].extension}`);
        }
      }
    });
  }

}
