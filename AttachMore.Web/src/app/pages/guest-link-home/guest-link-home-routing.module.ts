import { NgModule } from '@angular/core';
import { RouterModule, Route } from '@angular/router';

import { GuestLinkHomeComponent } from './guest-link-home.component';

export const HOME_COMPONENTS = [
    GuestLinkHomeComponent
];

const HOME_ROUTES: Route[] = [
    {
        path: '', component: GuestLinkHomeComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(HOME_ROUTES)],
    exports: [RouterModule]
})
export class GuestLinkHomeRoutingModule { }
