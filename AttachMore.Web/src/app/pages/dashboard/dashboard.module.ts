import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule } from '@angular/router';

import { DashboardComponent } from './dashboard.component';
import { AmSharedModule } from '../../shared/am-shared.module';

const DASHBOARD_ROUTES: Route[] = [
  {
    path: '', component: DashboardComponent
  }
];


@NgModule({
  declarations: [DashboardComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(DASHBOARD_ROUTES),
    AmSharedModule
  ],
})
export class DashboardModule { }
