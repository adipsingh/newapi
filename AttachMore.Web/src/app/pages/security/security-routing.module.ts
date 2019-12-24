import { NgModule } from '@angular/core';
import { RouterModule, Route } from '@angular/router';

import { SecurityComponent } from './security.component';

export const SECURITY_COMPONENTS = [
    SecurityComponent
];

const SECURITY_ROUTES: Route[] = [
    {
        path: '', component: SecurityComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(SECURITY_ROUTES)],
    exports: [RouterModule]
})
export class SecurityRoutingModule { }
