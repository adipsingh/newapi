import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule } from '@angular/router';

import { AmSharedModule } from '../../shared/am-shared.module';
import { AddFreeComponent } from './add-free.component';

const ADD_FREE_ROUTES: Route[] = [
  {
    path: '', component: AddFreeComponent
  }
];

@NgModule({
  declarations: [AddFreeComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(ADD_FREE_ROUTES),
    AmSharedModule
  ] 
})
export class AddFreeModule { }
