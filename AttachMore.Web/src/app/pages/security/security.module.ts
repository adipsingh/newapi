import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SecurityRoutingModule, SECURITY_COMPONENTS } from './security-routing.module';
import { AmSharedModule } from '../../shared/am-shared.module';

@NgModule({
  declarations: [...SECURITY_COMPONENTS],
  imports: [
    CommonModule,
    SecurityRoutingModule,
    AmSharedModule,
  ]
})
export class SecurityModule { }
