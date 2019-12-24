import { Component, Input } from '@angular/core';

import { Attachment } from '../../../models';
import { AttachmentService } from '../../../services/attachment.service';
import { NotificationService } from '../../../services/notification.service';
import { MESSAGES } from 'src/app/configuration/success.msg';

@Component({
  selector: 'am-attachment-name',
  templateUrl: './attachment-name.component.html',
  styleUrls: ['./attachment-name.component.scss']
})
export class AttachmentNameComponent {

  @Input() attachment: Attachment;

  constructor(private attachmentService: AttachmentService,
    private notiicationService: NotificationService) {
  }

  /**
   * Save Attachment Name
   */
  saveAttachmentName(name: string) {
    if (!name) {
      return;
    }
    const DATA = {
      attachmentId: this.attachment.attachmentId,
      attachmentName: name,
    };
    this.attachmentService.upadateAttachmentName(DATA).subscribe(res => {
      this.notiicationService.notify(MESSAGES.attachmentName);
    });
  }
}
