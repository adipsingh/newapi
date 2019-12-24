import { Directive, ElementRef, Renderer2 } from '@angular/core';
import { Router, Event, ActivationStart } from '@angular/router';

@Directive({
  selector: '[amHeaderColor]'
})
export class HeaderColorDirective {

  constructor(private router: Router, private el: ElementRef, private renderer: Renderer2) {
    this.router.events.subscribe((event: Event) => {
      if (event instanceof ActivationStart) {
        if (event.snapshot.data.needHeaderColor) {
          this.renderer.addClass(this.el.nativeElement, 'headerColor');
        } else {
          this.renderer.removeClass(this.el.nativeElement, 'headerColor');
        }
      }
    });
  }

}
