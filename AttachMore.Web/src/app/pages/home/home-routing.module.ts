import { NgModule } from '@angular/core';
import { RouterModule, Route } from '@angular/router';

import { HomeComponent } from './home.component';

export const HOME_COMPONENTS = [
    HomeComponent
];

const HOME_ROUTES: Route[] = [
    {
        path: '', component: HomeComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(HOME_ROUTES)],
    exports: [RouterModule]
})
export class HomeRoutingModule { }
