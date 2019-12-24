import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Route } from '@angular/router';

import { UploadProgressComponent } from './upload-progress.component';

import { AmSharedModule } from '../../shared/am-shared.module';

const UPLOAD_PROGRESS_ROUTES: Route[] = [
  {
    path: '', component: UploadProgressComponent
  }
];

@NgModule({
  declarations: [UploadProgressComponent],
  imports: [CommonModule, RouterModule.forChild(UPLOAD_PROGRESS_ROUTES), AmSharedModule]
})
export class UploadProgressModule { }
