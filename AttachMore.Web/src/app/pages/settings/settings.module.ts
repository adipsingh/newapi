import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Route } from '@angular/router';

import { AmSharedModule } from '../../shared/am-shared.module';
import { SettingsComponent } from './settings.component';

const SETTINGS_ROUTES: Route[] = [
  {
      path: '', component: SettingsComponent
  }
];

@NgModule({
  declarations: [SettingsComponent],
  imports: [
    CommonModule,
    AmSharedModule,
    RouterModule.forChild(SETTINGS_ROUTES)
  ]
})
export class SettingsModule { }
