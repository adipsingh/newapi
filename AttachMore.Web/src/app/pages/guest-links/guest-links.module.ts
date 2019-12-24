import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Route } from '@angular/router';

import { AmSharedModule } from '../../shared/am-shared.module';
import { GuestLinksComponent} from './guest-links.component';


const GUEST_LINK_ROUTES: Route[] = [
  {
    path: '', component: GuestLinksComponent
  }
];

@NgModule({
  declarations: [GuestLinksComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(GUEST_LINK_ROUTES),
    AmSharedModule
  ]
})
export class GuestLinksModule { }
