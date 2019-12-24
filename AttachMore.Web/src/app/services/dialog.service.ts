import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material';

import { AmConfirmationComponent } from '../shared/dialogs/am-confirmation/am-confirmation.component';
import { WelcomeComponent } from '../shared/dialogs/welcome/welcome.component';
import { DownloadAttachmentComponent } from '../shared/dialogs/download-attachment/download-attachment.component';
import { GuestLinkComponent } from '../shared/dialogs/guest-link/guest-link.component';
import { Confirmation } from '../shared/dialogs/am-confirmation/confirmation';
import { SecuritySettings } from '../models';
import { PlanPricingComponent } from '../shared/dialogs/plan-pricing/plan-pricing.component';
import { Observable } from 'rxjs';
import { FreeUserComponent } from '../shared/dialogs/free-user/free-user.component';


@Injectable({
    providedIn: 'root'
})
export class DialogService {

    constructor(private dialog: MatDialog) {
    }

    /**
     * Welcome Dialog
     */
    welcomeDialog(): Observable<any> {
        const dialogRef = this.dialog.open(WelcomeComponent);

        return dialogRef.afterClosed();
    }

    /**
     * Plan and Pricing dialog
     */
    planAndPricingDialog(): Observable<any> {
        const dialogRef = this.dialog.open(PlanPricingComponent);
        return dialogRef.afterClosed();
    }

     /**
     * free user dialog
     */
    freeUserDialog(): Observable<any> {
        const dialogRef = this.dialog.open(FreeUserComponent);
        return dialogRef.afterClosed();
    }

    /**
     * Confirmation Dialog
     * @param data
     */
    confirmationDialog(data: Confirmation) {
        const dialogRef = this.dialog.open(AmConfirmationComponent, {
            data: data
        });
        return dialogRef.afterClosed();
    }

     /**
     * Download attachment Dialog
     * @param data
     */
    downloadAttachmentDialog(data: SecuritySettings) {
        const dialogRef = this.dialog.open(DownloadAttachmentComponent, {
            data: data
        });
        return dialogRef.afterClosed();
    }

    /**
     * Guest link Dialog
     * @param data
     */
    guestLinkDialog(data: string) {
        const dialogRef = this.dialog.open(GuestLinkComponent, {
            data: data
        });
        return dialogRef.afterClosed();
    }
}
