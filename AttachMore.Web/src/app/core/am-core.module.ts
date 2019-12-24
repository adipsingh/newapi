import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AmSharedModule } from '../shared/am-shared.module';
import { AmHeaderComponent } from './components/am-header/am-header.component';
import { AmFooterComponent } from './components/am-footer/am-footer.component';
import { AmMainComponent } from './components/am-main/am-main.component';
import { ProgressBarComponent } from './components/progress-bar/progress-bar.component';

@NgModule({
    declarations: [
        AmHeaderComponent,
        AmFooterComponent,
        AmMainComponent,
        ProgressBarComponent
    ],
    imports: [
        BrowserAnimationsModule,
        RouterModule,
        HttpClientModule,
        AmSharedModule,
    ],
    exports: [
        BrowserAnimationsModule,
        AmSharedModule,
        AmHeaderComponent,
        AmFooterComponent,
        AmMainComponent
    ]
})
export class AmCoreModule {
}
