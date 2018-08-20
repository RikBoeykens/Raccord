import { Pipe, PipeTransform } from '@angular/core';
import { TimespanHelpers } from '../helpers/timespan.helpers';

@Pipe({name: 'myTimespan'})
export class TimespanPipe implements PipeTransform {
  public transform(value: number): string {
    return TimespanHelpers.getTimespanString(value);
  }
}
