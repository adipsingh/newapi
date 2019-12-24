import { Component, OnInit, ViewChild, ElementRef, Input } from '@angular/core';

@Component({
  selector: 'am-download-link',
  templateUrl: './download-link.component.html',
  styleUrls: ['./download-link.component.scss']
})
export class DownloadLinkComponent implements OnInit {
  downloadLink: string;
  @Input() name: string;
  @Input() label = 'Here is the download link:';

  @ViewChild('linkInput') linkInput: ElementRef;
  @ViewChild('copyLinkBtnToolTip') copyLinkBtnToolTip: ElementRef;

  constructor() {
  }

  ngOnInit() {
    this.name = this.name ? this.name : '';
  }


  /**
   * copy text of link input
   */
  copyLink() {
    const copyText = this.linkInput.nativeElement;
    copyText.select();
    document.execCommand('copy');
    this.copyLinkBtnToolTip.nativeElement.textContent = 'Copied';
  }

  /**
   * -- reset copy to clipboard text on mouse out
   */
  whenFocusOut() {
    this.copyLinkBtnToolTip.nativeElement.textContent = 'Copy to clipboard';
  }

}
