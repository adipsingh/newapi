import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule } from '@angular/router';

import { FeaturesComponent } from './features.component';
import { AmSharedModule } from '../../shared/am-shared.module';

const FEATURES_ROUTES: Route[] = [
  {
    path: '', component: FeaturesComponent
  }
];

@NgModule({
  declarations: [FeaturesComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(FEATURES_ROUTES),
    AmSharedModule
  ]
})
export class FeaturesModule { }
