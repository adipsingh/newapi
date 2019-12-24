import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { Confirmation } from './confirmation';

@Component({
  selector: 'am-confirmation',
  templateUrl: './am-confirmation.component.html',
  styleUrls: ['./am-confirmation.component.scss']
})
export class AmConfirmationComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<AmConfirmationComponent>,
    @Inject(MAT_DIALOG_DATA) public data?: Confirmation) { }

  ngOnInit() {
  }

}
