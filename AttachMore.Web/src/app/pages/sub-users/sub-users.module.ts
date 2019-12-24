import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Route } from '@angular/router';

import { AmSharedModule } from '../../shared/am-shared.module';
import { SubUsersComponent } from './sub-users.component';

const SUB_USERS_ROUTES: Route[] = [
  {
    path: '', component: SubUsersComponent
  }
];

@NgModule({
  declarations: [SubUsersComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(SUB_USERS_ROUTES),
    AmSharedModule
  ]
})
export class SubUsersModule { }
