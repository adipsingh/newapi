import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

import { FilesHistory } from '../../../models';
import { FileStatus } from '../../../enum';
import { ICONS_MAPPER } from '../../../untility';

@Component({
  selector: 'am-list-view',
  templateUrl: './list-view.component.html',
  styleUrls: ['./list-view.component.scss']
})

export class ListViewComponent implements OnInit {

  @Input() files: FilesHistory[];
  fileStatus = FileStatus;
  icons = ICONS_MAPPER;

  constructor(private route: Router) { }

  ngOnInit() {
  }

   /**
  * Navigate to Attachment Details
  * @param fileHistory
  */
 navigateToDetails(fileHistory: FilesHistory) {
  this.route.navigate(['attachmentDetails', fileHistory.attachmentId]);
}

}
