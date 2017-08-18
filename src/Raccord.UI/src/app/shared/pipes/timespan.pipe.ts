import { Pipe, PipeTransform } from '@angular/core';
import { TimespanHelpers } from '../helpers/timespan.helpers';

@Pipe({name: 'timespan'})
export class TimespanPipe implements PipeTransform {
  transform(value: number): string {
    return TimespanHelpers.getTimespanString(value);
  }
}