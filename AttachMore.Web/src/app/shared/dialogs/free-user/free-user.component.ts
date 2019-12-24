import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'am-free-user',
  templateUrl: './free-user.component.html',
  styleUrls: ['./free-user.component.scss']
})
export class FreeUserComponent implements OnInit {

  constructor(private router: Router, private dialogRef: MatDialogRef<FreeUserComponent>) { }

  ngOnInit() {
  }

  /**
   * shop plans
   */
  shopPlans() {
    this.router.navigate(['plan&pricing']);
    this.dialogRef.close(false);
  }
}
