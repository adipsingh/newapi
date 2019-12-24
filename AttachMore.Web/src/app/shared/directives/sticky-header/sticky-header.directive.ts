import { Directive, HostListener, Renderer2, ElementRef, OnInit, Inject } from '@angular/core';
import { DOCUMENT } from '@angular/common';

declare const window: Window;

@Directive({
  selector: '[amStickyHeader]'
})
export class StickyHeaderDirective implements OnInit {

  constructor(private renderer: Renderer2, private el: ElementRef, @Inject(DOCUMENT) private document: any) { }

  // handle body scroll
  @HostListener('body:scroll', ['$event']) public windowScrolled($event: Event) {
    this.windowScrollEvent($event);
  }

  /**
   * Handles window scroll event
   * @param event
   */
  private windowScrollEvent(event: Event) {
    const scrollTop =  document.body.scrollTop || 0;
    if (scrollTop > 1) {
      this.renderer.addClass(this.el.nativeElement, 'sticky');
    } else {
       this.renderer.removeClass(this.el.nativeElement, 'sticky');
    }
  }

  ngOnInit() {

  }

}
