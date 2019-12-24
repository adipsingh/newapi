import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { Router, NavigationStart, Event, ActivationStart } from '@angular/router';

import { SigninComponent } from '../../../shared/dialogs/auth/signin/signin.component';
import { SignupComponent } from '../../../shared/dialogs/auth/signup/signup.component';
import { AuthService } from '../../../services/auth.service';
import { AuthDialogService } from '../../../services/auth-dialog.service';
import { DialogService } from '../../../services/dialog.service';
import { PageType } from '../../../enum';

@Component({
  selector: 'am-header',
  templateUrl: './am-header.component.html',
  styleUrls: ['./am-header.component.scss']
})
export class AmHeaderComponent implements OnInit {

  isDownwloadpage = false;
  headerType: PageType;
  pageType = PageType;

  constructor(private dialog: MatDialog,
    public authService: AuthService,
    public authDialogService: AuthDialogService,
    private dialogService: DialogService,
    private router: Router) { }

  ngOnInit() {

    this.router.events.subscribe((event: Event) => {
      if (event instanceof ActivationStart) {
        this.headerType = event.snapshot.data.pageType;
        }
    });
  }

  /**
   * Open Signin Form
   */
  openSigninForm() {
    const dialogRef = this.dialog.open(SigninComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.dialogService.planAndPricingDialog().subscribe(res => {
        });
      }
    });
  }

  /**
   * Open Register Form
   */
  openRegisterForm() {
    const dialogRef = this.dialog.open(SignupComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
      }
    });
  }

  /**
   * Naviate to upload
   */
  navigateToUpload() {
    if (this.router.routerState.snapshot.url === '/upload_progress') {
      this.dialogService.confirmationDialog({ title: 'Alert', message: 'your data will lost. Do you want to continue?' }).subscribe(res => {
        if (res) {
          this.router.navigate(['/']);
        }
      });
    } else {
      this.router.navigate(['/']);
    }
  }

}
