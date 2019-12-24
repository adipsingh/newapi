import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

import { FileUploadModule } from 'ng2-file-upload';
import { SwiperModule } from 'angular2-useful-swiper';

import { AmMaterialModule } from './am-material.module';
import { AM_SHARED_COMPONENTS } from './components';
import { AM_SHARED_DIRECTIVES } from './directives';
import { AM_SHARED_PIPES } from './pipes';

import { MAT_DIALOG_DEFAULT_OPTIONS } from '@angular/material';
import { MAT_DIALOG_CONFIG } from '../configuration/mat-dialog.config';

// Dialogs
import { SigninComponent } from './dialogs/auth/signin/signin.component';
import { SignupComponent } from './dialogs/auth/signup/signup.component';
import { WelcomeComponent } from './dialogs/welcome/welcome.component';
import { PasswordComponent } from './dialogs/auth/password/password.component';
import { AmConfirmationComponent } from './dialogs/am-confirmation/am-confirmation.component';
import { DownloadAttachmentComponent } from './dialogs/download-attachment/download-attachment.component';
import { ForgetPasswordComponent } from './dialogs/auth/forget-password/forget-password.component';
import { PlanPricingComponent } from './dialogs/plan-pricing/plan-pricing.component';
import { FreeUserComponent } from './dialogs/free-user/free-user.component';
import { GuestLinkComponent } from './dialogs/guest-link/guest-link.component';

const SHARED_DIALOG_COMPONENTS = [
    SigninComponent,
    SignupComponent,
    WelcomeComponent,
    PasswordComponent,
    AmConfirmationComponent,
    DownloadAttachmentComponent,
    ForgetPasswordComponent,
    PlanPricingComponent,
    FreeUserComponent,
    GuestLinkComponent
];

@NgModule({
    declarations: [
        ...AM_SHARED_COMPONENTS,
        ...AM_SHARED_DIRECTIVES,
        ...AM_SHARED_PIPES,
        ...SHARED_DIALOG_COMPONENTS
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        AmMaterialModule,
        FlexLayoutModule,
        FileUploadModule,
        SwiperModule,
        BsDatepickerModule.forRoot()
    ],
    entryComponents: [
        ...SHARED_DIALOG_COMPONENTS
    ],
    providers: [
        {
            provide: MAT_DIALOG_DEFAULT_OPTIONS,
            useValue: MAT_DIALOG_CONFIG
        }],
    exports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        FlexLayoutModule,
        AmMaterialModule,
        FileUploadModule,
        ...AM_SHARED_COMPONENTS,
        ...AM_SHARED_DIRECTIVES,
        ...AM_SHARED_PIPES
    ]
})
export class AmSharedModule { }
