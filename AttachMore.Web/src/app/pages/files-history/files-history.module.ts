import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule } from '@angular/router';

import { AmSharedModule } from '../../shared/am-shared.module';
import { FilesHistoryComponent } from './files-history.component';
import { ThumbnailViewComponent } from './thumbnail-view/thumbnail-view.component';
import { ListViewComponent } from './list-view/list-view.component';

const FILES_HISTORY_ROUTES: Route[] = [
  {
    path: '', component: FilesHistoryComponent
  }
];


@NgModule({
  declarations: [FilesHistoryComponent, ThumbnailViewComponent, ListViewComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(FILES_HISTORY_ROUTES),
    AmSharedModule
  ],
})
export class FilesHistoryModule { }
