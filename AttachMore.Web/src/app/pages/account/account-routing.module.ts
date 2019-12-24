import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule } from '@angular/router';

import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { ChangePasswordComponent } from './change-password/change-password.component';

import { AuthGuardService } from '../../guards/auth-guard.service';

export const ACCOUNT_COMPONENTS = [
    ResetPasswordComponent,
    ChangePasswordComponent
];

const ACCOUNT_ROUTES: Route[] = [
    {
        path: 'resetPassword', component: ResetPasswordComponent
    },
    {
        path: 'changePassword', canActivate: [AuthGuardService], component: ChangePasswordComponent
    }
];

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        RouterModule.forChild(ACCOUNT_ROUTES)
    ],
    exports: [RouterModule]
})
export class AccountRoutingModule { }
