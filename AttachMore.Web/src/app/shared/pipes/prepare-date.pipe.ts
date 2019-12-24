import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'prepareDate'
})
export class PrepareDatePipe implements PipeTransform {

  transform(value: any, args?: string): any {
    if (value) {
      args = args ? args : '_';
      const dateArr = [];
      const DATE = new Date(value);
      dateArr.push(DATE.getMonth() + 1);
      dateArr.push(DATE.getDate());
      dateArr.push(DATE.getFullYear());
      return dateArr.join(args);
    }
    return null;
  }

}
