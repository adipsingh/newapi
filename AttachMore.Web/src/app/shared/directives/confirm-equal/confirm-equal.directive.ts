import { Directive, Input } from '@angular/core';
import { Validator, AbstractControl, NG_VALIDATORS } from '@angular/forms';

@Directive({
  selector: '[amConfirmEqual]',
  providers: [{
    provide: NG_VALIDATORS,
    useExisting: ConfirmEqualDirective,
    multi: true
  }]
})
export class ConfirmEqualDirective implements Validator {

  @Input() amConfirmEqual: string;

  constructor() { }

  validate(control: AbstractControl): { [key: string]: any } | null {
    const controlToCompare = control.parent.get(this.amConfirmEqual);
    if (controlToCompare && controlToCompare.value !== control.value) {
      return { confirmEqual: true };
    }
    return null;
  }
}
