import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule } from '@angular/router';

import { AmSharedModule } from '../../shared/am-shared.module';
import { BenefitsComponent } from './benefits.component';

const BENEFITS_ROUTES: Route[] = [
  {
    path: '', component: BenefitsComponent
  }
];

@NgModule({
  declarations: [BenefitsComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(BENEFITS_ROUTES),
    AmSharedModule
  ]
})
export class BenefitsModule { }
