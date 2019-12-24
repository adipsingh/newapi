import { Component, OnInit } from '@angular/core';

import { DashboardService } from '../../services/dashboard.service';
import { AttachmentDetails, ExpirySettings, NotificationSettings, SecuritySettings } from 'src/app/models';
import { ActivatedRoute, Params } from '@angular/router';
import { ICONS_MAPPER } from '../../untility';
import { FileStatus } from 'src/app/enum';

import * as moment from 'moment';

@Component({
  selector: 'am-attachment-details',
  templateUrl: './attachment-details.component.html',
  styleUrls: ['./attachment-details.component.scss']
})
export class AttachmentDetailsComponent implements OnInit {

  attachment: AttachmentDetails = <AttachmentDetails>{};
  icons = ICONS_MAPPER;
  fileStatus = FileStatus;
  expirySettings: ExpirySettings = <ExpirySettings>{};
  notificationSettings: NotificationSettings = <NotificationSettings>{};
  securitySettings: SecuritySettings = <SecuritySettings>{};

  constructor(private route: ActivatedRoute, public dashboardService: DashboardService) { }

  ngOnInit() {
    this.route.params.subscribe((res: Params) => {
      this.dashboardService.getAttachmentDetails(+res.id).subscribe(response => {
        this.getFilesExtension(response);
        this.intializeSettings(response);
      });
    });
  }

  intializeSettings(attachmentPreview: AttachmentDetails) {
    this.expirySettings = {
      attachmentId: attachmentPreview.attachmentId,
      downloadsLimit: attachmentPreview.downloadLimit,
      expiryDate: moment(attachmentPreview.expiredOn),
      deletionDate: moment(attachmentPreview.deleteAfter)
    };

    this.notificationSettings = {
      attachmentId: attachmentPreview.attachmentId,
      whenExpired: attachmentPreview.whenExpired,
      whenDownload: attachmentPreview.whenDownload,
      byEmail: attachmentPreview.byEmail,
      byText: attachmentPreview.byText
    };

    this.securitySettings = {
      attachmentId: attachmentPreview.attachmentId,
      accessPassword: attachmentPreview.accessPassword,
      accessEmail: attachmentPreview.accessEmail,
      accessName: attachmentPreview.accessName,
      accessCompany: attachmentPreview.accessCompany,
      accessContactNumber: attachmentPreview.accessContectNumber,
      accessPayment: attachmentPreview.accessPayment
    };
  }
  /**
   * Get files extension
   * @param res
   */
  getFilesExtension(attachmentPreview: AttachmentDetails): void {
    attachmentPreview.filesDetail.forEach((file) => {
      file.extension = file.fileName.split('.').pop().toLowerCase();
      file.isImage = file.fileType.includes('image');
    });

    this.attachment = this.getAttachmentExtension(attachmentPreview);
  }

  /**
  * Get Attachment extension
  * @param attachmentPreview
  */
  getAttachmentExtension(attachmentPreview: AttachmentDetails) {
    if (attachmentPreview.filesDetail.length === 1) {
      attachmentPreview.extension = attachmentPreview.filesDetail[0].extension;
      attachmentPreview.isImage = attachmentPreview.filesDetail[0].isImage;
    } else if (attachmentPreview.filesDetail.length > 1) {
      attachmentPreview.extension = 'zip';
      attachmentPreview.isImage = false;
    } else {
      attachmentPreview.extension = null;
      attachmentPreview.isImage = false;
    }
    return attachmentPreview;
  }
}
