import { Component, OnInit } from '@angular/core';

import { UploadService } from '../../../services/upload.service';

@Component({
  selector: 'am-upload-spinner',
  templateUrl: './upload-spinner.component.html',
  styleUrls: ['./upload-spinner.component.scss']
})
export class UploadSpinnerComponent implements OnInit {

  constructor(public uploadService: UploadService) { }

  ngOnInit() {
  }

}
