import { Component, OnInit } from '@angular/core';

import { GuestLink } from '../../models/guest-link.model';
import { GuestLinksService } from '../../services/guest-links.service';
import { DialogService } from 'src/app/services/dialog.service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'am-guest-links',
  templateUrl: './guest-links.component.html',
  styleUrls: ['./guest-links.component.scss']
})
export class GuestLinksComponent implements OnInit {
  guestLinks: GuestLink[];
  linkName = new FormControl();

  constructor(private guestLinksService: GuestLinksService, private dialogService: DialogService) { }

  ngOnInit() {
    this.loadGuestLink();
  }

  /**
   * load Guest link
   */
  loadGuestLink() {
    this.guestLinksService.getGuestLinks().subscribe(res => {
      this.guestLinks = res;
    });
  }
  createGuestLink() {
    this.dialogService.guestLinkDialog(this.linkName.value).subscribe(res => {
      if (res) {
        this.loadGuestLink();
      }
    });
  }
}
