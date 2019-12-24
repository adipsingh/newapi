import { Directive, HostListener, Input, OnInit, DebugElement, ElementRef } from '@angular/core';

@Directive({
  selector: '[amNumberOnly]'
})
export class NumberOnlyDirective implements OnInit {

  @Input() allowDot = false;
  // Allow: 8=Backspace, 9= Tab, 13=CR, 27=ESC, 35=END, 36=HOME, 37=Left, 39=Right, 46=DEL
  allowedKeys = [8, 9, 13, 27, 35, 36, 37, 39, 46];

  ngOnInit(): void {
    if (this.allowDot) {
      // 190= dot
      this.allowedKeys.push(190);
    }
  }

  @HostListener('keydown', ['$event'])
  onKeyDown(event): undefined {
    const e = event as KeyboardEvent;

    if (this.allowDot) {
      if (this.hasDot((e.target as any).value) && e.keyCode === 190) {
        e.preventDefault();
        return;
      }
    }
    if (this.allowedKeys.indexOf(e.keyCode) !== -1) {
      return;
    }

    // Ensure that it is a number and stop the keypress
    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
      e.preventDefault();
      return;
    }
  }

  /**
   * @description check if value has dot or not
   * @param value
   * @returns boolean
   */
  hasDot(value: string): boolean {
    if (!value) {
      return false;
    }
    return value.indexOf('.') > -1;
  }
}
