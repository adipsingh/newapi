import { Component, AfterViewInit, Input } from '@angular/core';

@Component({
  selector: 'am-fb-like',
  templateUrl: './fb-like.component.html',
  styleUrls: ['./fb-like.component.scss']
})
export class FbLikeComponent implements AfterViewInit {

  @Input() url = location.href;

  constructor() {
    // initialise facebook sdk after it loads if required
    if (!window['fbAsyncInit']) {
      window['fbAsyncInit'] = function () {
        window['FB'].init({
          appId: '304894386860617',
          autoLogAppEvents: true,
          xfbml: true,
          version: 'v3.0'
        });
      };
    }

    // load facebook sdk if required
    const url = 'https://connect.facebook.net/en_US/sdk.js';
    if (!document.querySelector(`script[src='${url}']`)) {
      const script = document.createElement('script');
      script.src = url;
      document.body.appendChild(script);
    }
  }

  ngAfterViewInit(): void {
    // render facebook button
    // tslint:disable-next-line:no-unused-expression
    window['FB'] && window['FB'].XFBML.parse();
  }
}
