import { Component, OnInit, Optional, Inject } from '@angular/core';
import { GuestLinksService } from 'src/app/services/guest-links.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { GuestLink } from '../../../models/guest-link.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'am-guest-link',
  templateUrl: './guest-link.component.html',
  styleUrls: ['./guest-link.component.scss']
})
export class GuestLinkComponent implements OnInit {

  currentDate = new Date();
  guestLink: GuestLink = <GuestLink>{};
  guestLinkData: GuestLink ;
  guestLinkForm: FormGroup;
  lkName: string;
  lkUrl: string;
  guestLkID: number;

  constructor(private guestLinkService: GuestLinksService,
    private dialogRef: MatDialogRef<GuestLinkComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) public receivedGuestName: string) {
  }

  ngOnInit() {
    
    this.lkUrl = this.guestLink.linkUrl = `${window.location.origin}/guestLink`.random(10);
    this.lkName = this.guestLink.linkName = this.receivedGuestName;
    this.initalizeForm();

    const JSON_DATA: GuestLink = {
      linkName: this.guestLink.linkName,
      linkUrl: this.guestLink.linkUrl,
      status: 1,
      ...this.guestLinkForm.value
    };

    this.guestLinkService.generateGuestLinks(JSON_DATA).subscribe(result => {
      if (result) {
        //this.dialogRef.close(result);
        var json = JSON.parse(result);
       // this.guestLinkData=result;
        this.guestLkID = json["guestLinkID"];
      }
    });

  }

  initalizeForm(): void {
    this.guestLinkForm = new FormGroup({
      expirySettings: new FormGroup({
        uploadLimit: new FormControl(250, Validators.required),
        numberOfUses: new FormControl(5, Validators.required),
        expirationDate: new FormControl(new Date(this.currentDate.setDate(this.currentDate.getDate() + 5)))
      }),
      notifySettings: new FormGroup({
        onDownloaded: new FormControl(true),
        onExpired: new FormControl(true),
        byEmail: new FormControl(true),
        byText: new FormControl(true)
      }),
      securitySettings: new FormGroup({
        email: new FormControl(true),
        company: new FormControl(true),
        name: new FormControl(true),
        phone: new FormControl(true),
        password: new FormControl(true),
        passwordProtectedPage: new FormControl(true)
      })
    });
  }

  /**
   * Update Guest Name
   * @param name
   */
  updateGuestName(name: string): void {
    this.guestLink.linkName = name;
  }

  /**
   * Save guest Link
   * @param name
   */
  saveGuestLink(name: string): void {
    const JSON_DATA: GuestLink = {
      linkName: this.guestLink.linkName,
      linkUrl: this.guestLink.linkUrl,
      status: 1,      
      guestLinkID: this.guestLkID,
      ...this.guestLinkForm.value
    };

    this.guestLinkService.generateGuestLinks(JSON_DATA).subscribe(result => {
      if (result) {
        this.dialogRef.close(result);
      }
    });
  }

}
