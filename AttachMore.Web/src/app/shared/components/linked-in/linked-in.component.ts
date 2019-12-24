import { Component, AfterViewInit, ElementRef, ViewChild, Input } from '@angular/core';

@Component({
  selector: 'am-linked-in',
  templateUrl: './linked-in.component.html',
  styleUrls: ['./linked-in.component.scss']
})
export class LinkedInComponent implements AfterViewInit {

  @Input() set url(url: string) {
    if (url) {
      this.addLinkedInShareButton(url);
    }
  }
  @ViewChild('element') element: ElementRef;

  constructor() {
    // load twitter sdk if required
    const url = 'https://platform.linkedin.com/in.js';
    if (!document.querySelector(`script[src='${url}']`)) {
      const script = document.createElement('script');
      script.src = url;
      script.innerHTML = ' lang: en_US';
      document.body.appendChild(script);
    }
  }

  addLinkedInShareButton(url): void {
    // add linkedin share button script tag to element
    this.element.nativeElement.innerHTML = `<script type="IN/Share" data-url="${url}"></script>`;
        // render share button
    // tslint:disable-next-line:no-unused-expression
    window['IN'] && window['IN'].parse();
  }

  ngAfterViewInit(): void {

  }
}
