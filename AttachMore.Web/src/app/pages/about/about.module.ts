import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule } from '@angular/router';

import { AmSharedModule } from '../../shared/am-shared.module';
import { AboutComponent } from './about.component';

const ABOUT_ROUTES: Route[] = [
  {
    path: '', component: AboutComponent
  }
];

@NgModule({
  declarations: [AboutComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(ABOUT_ROUTES),
    AmSharedModule
  ] 
})
export class AboutModule { }
