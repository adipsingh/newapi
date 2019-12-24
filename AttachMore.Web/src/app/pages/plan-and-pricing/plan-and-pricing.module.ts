import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule } from '@angular/router';

import { AmSharedModule } from '../../shared/am-shared.module';
import { PlanAndPricingComponent } from './plan-and-pricing.component';

const PLAN_PRICING_ROUTES: Route[] = [
  {
    path: '', component: PlanAndPricingComponent
  }
];

@NgModule({
  declarations: [PlanAndPricingComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(PLAN_PRICING_ROUTES),
    AmSharedModule
  ]
})
export class PlanAndPricingModule { }
