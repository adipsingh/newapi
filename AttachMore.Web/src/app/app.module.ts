import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MAT_DIALOG_DEFAULT_OPTIONS } from '@angular/material';

import { AppComponent } from './app.component';
import { AmCoreModule } from './core/am-core.module';
import { AppRoutingModule } from './app-routing.module';
import { HTTP_INTERCEPTORS_PROVIDERS } from './http-interceptors';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { JwSocialButtonsModule } from 'jw-angular-social-buttons';

import './extensions/string.extension';

@NgModule({
  declarations: [
    AppComponent,
    NotFoundComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    JwSocialButtonsModule,
    AmCoreModule,
  ],
  providers: [
    HTTP_INTERCEPTORS_PROVIDERS,
    {provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: {hasBackdrop: false, disableClose: true}}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
