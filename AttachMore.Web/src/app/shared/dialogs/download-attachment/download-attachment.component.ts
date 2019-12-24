import { Component, OnInit, Inject} from '@angular/core';
import { DownloadAttachment, SecuritySettings } from 'src/app/models';
import { MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'am-download-attachment',
  templateUrl: './download-attachment.component.html',
  styleUrls: ['./download-attachment.component.scss']
})
export class DownloadAttachmentComponent implements OnInit {

  model: DownloadAttachment = <DownloadAttachment>{};
  constructor(@Inject(MAT_DIALOG_DATA) public data: SecuritySettings) { }

  ngOnInit() {
  }

}
