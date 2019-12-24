import { Component, AfterViewInit, Input } from '@angular/core';

@Component({
  selector: 'am-tweet',
  templateUrl: './tweet.component.html',
  styleUrls: ['./tweet.component.scss']
})
export class TweetComponent implements AfterViewInit {

  @Input() url = location.href;
  @Input() text = '';

  constructor() {
    // load twitter sdk if required
    const url = 'https://platform.twitter.com/widgets.js';
    if (!document.querySelector(`script[src='${url}']`)) {
      const script = document.createElement('script');
      script.src = url;
      document.body.appendChild(script);
    }
  }

  ngAfterViewInit(): void {
    // render tweet button
    // tslint:disable-next-line:no-unused-expression
    window['twttr'] && window['twttr'].widgets.load();
  }

}
