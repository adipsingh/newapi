import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AmSharedModule } from '../../shared/am-shared.module';
import { GuestLinkHomeRoutingModule, HOME_COMPONENTS } from './guest-link-home-routing.module';

@NgModule({
  declarations: [HOME_COMPONENTS],
  imports: [
    CommonModule,
    GuestLinkHomeRoutingModule,
    AmSharedModule
  ]
})
export class GuestLinkHomeModule { }
