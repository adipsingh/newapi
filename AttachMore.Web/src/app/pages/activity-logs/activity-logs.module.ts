import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Route } from '@angular/router';

import { AmSharedModule } from '../../shared/am-shared.module';
import { ActivityLogsComponent } from './activity-logs.component';

const ACTIVITY_LOGS_ROUTES: Route[] = [
  {
    path: '', component: ActivityLogsComponent
  }
];


@NgModule({
  declarations: [ActivityLogsComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(ACTIVITY_LOGS_ROUTES),
    AmSharedModule
  ],
})
export class ActivityLogsModule { }
