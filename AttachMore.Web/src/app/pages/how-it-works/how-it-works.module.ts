import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule } from '@angular/router';

import { AmSharedModule } from '../../shared/am-shared.module';
import { HowItWorksComponent } from './how-it-works.component';

const HOW_IT_WORKS_ROUTES: Route[] = [
  {
    path: '', component: HowItWorksComponent
  }
];

@NgModule({
  declarations: [HowItWorksComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(HOW_IT_WORKS_ROUTES),
    AmSharedModule
  ]
})
export class HowItWorksModule { }
