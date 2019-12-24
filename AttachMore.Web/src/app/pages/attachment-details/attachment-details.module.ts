import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Route } from '@angular/router';

import { AmSharedModule } from '../../shared/am-shared.module';
import { AttachmentDetailsComponent } from './attachment-details.component';

const ATTACHMENTDETAILS_ROUTES: Route[] = [
  {
    path: ':id', component: AttachmentDetailsComponent
  }
];


@NgModule({
  declarations: [AttachmentDetailsComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(ATTACHMENTDETAILS_ROUTES),
    AmSharedModule
  ],
})
export class AttachmentDetailsModule { }
