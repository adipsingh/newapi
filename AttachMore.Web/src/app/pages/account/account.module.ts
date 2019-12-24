import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ACCOUNT_COMPONENTS, AccountRoutingModule } from './account-routing.module';
import { AmSharedModule } from '../../shared/am-shared.module';

@NgModule({
  declarations: [...ACCOUNT_COMPONENTS],
  imports: [
    CommonModule,
    AccountRoutingModule,
    AmSharedModule
  ]
})
export class AccountModule { }
