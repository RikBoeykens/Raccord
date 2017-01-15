import { Pipe, PipeTransform } from '@angular/core';
import { PageLengthHelpers } from '../helpers/page-length.helpers';

@Pipe({name: 'pagelength'})
export class PageLengthPipe implements PipeTransform {
  transform(value: number): string {
    return PageLengthHelpers.getPageLengthString(value);
  }
}