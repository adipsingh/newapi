import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material';
import { Subject } from 'rxjs';
import { tap } from 'rxjs/operators';

import { SignupComponent } from '../shared/dialogs/auth/signup/signup.component';
import { SigninComponent } from '../shared/dialogs/auth/signin/signin.component';
import { ForgetPasswordComponent } from '../shared/dialogs/auth/forget-password/forget-password.component';
import { PasswordComponent } from '../shared/dialogs/auth/password/password.component';
import { DialogService } from './dialog.service';

@Injectable({
    providedIn: 'root'
})
export class AuthDialogService {

    whenSignInDialogClosed = new Subject();
    whenRegisterDialogClosed = new Subject();

    constructor(private dialog: MatDialog, private dialogService: DialogService) {
    }

    /**
     * opens signin form
     */
    openSigninForm() {
        const dialogRef = this.dialog.open(SigninComponent);

        dialogRef.afterClosed().subscribe(result => {
            // this.whenSignInDialogClosed.next(result);
            if (!result.user.premiumStatus) {
                this.dialogService.freeUserDialog().subscribe(res => {
                    if (res) {
                       // this.dialogService.welcomeDialog().subscribe(welcomeRes => {
                        //});
                    }
                });
            } else {
                //this.dialogService.welcomeDialog().subscribe(welcomeRes => {
                //});
            }
        });
    }

    /**
     * open register form
     * @param email
     */
    openRegisterForm(email?: string) {
        const dialogRef = this.dialog.open(SignupComponent, {
            data: email
        });

        // return dialogRef.afterClosed().subscribe(result => {
        //     if (result) {
        //         this.dialogService.planAndPricingDialog().subscribe(res => {
        //             if (res) {
        //             }
        //             this.dialogService.welcomeDialog();
        //         });
        //     }
        // });
    }

    /**
     * Password Dialog
     * @param email
     */
    passwordDialog(email: string) {
        const dialogRef = this.dialog.open(PasswordComponent, {
            data: email
        });
        return dialogRef.afterClosed().pipe(tap((result) => {
            if (!result.user.premiumStatus) {
                this.dialogService.freeUserDialog().subscribe(res => {
                    if (res) {
                        // this.dialogService.welcomeDialog().subscribe(welcomeRes => {
                        // });
                    }
                });
            } else {
                // this.dialogService.welcomeDialog().subscribe(welcomeRes => {
                // });
            }
        }));
    }

    /**
    * password reset Dialog
    * @param data
    */
    forgetPasswordDialog(data: any) {
        const dialogRef = this.dialog.open(ForgetPasswordComponent, {
            data: data
        });
        return dialogRef.afterClosed();
    }
}
