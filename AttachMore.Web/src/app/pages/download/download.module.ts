import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Route } from '@angular/router';

import { DownloadComponent } from './download.component';
import { AmSharedModule } from 'src/app/shared/am-shared.module';
import { NotFoundComponent } from '../not-found/not-found.component';

const DOWNLOAD_ROUTES: Route[] = [
  {
    path: ':attachmentId', component: DownloadComponent
  }
];

@NgModule({
  declarations: [DownloadComponent],
  imports: [CommonModule, RouterModule.forChild(DOWNLOAD_ROUTES), AmSharedModule]
})
export class DownloadModule { }
