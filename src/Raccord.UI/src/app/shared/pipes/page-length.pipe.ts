import { Pipe, PipeTransform } from '@angular/core';
import { PageLengthHelpers } from '../helpers/page-length.helpers';

@Pipe({name: 'myPagelength'})
export class PageLengthPipe implements PipeTransform {
  public transform(value: number): string {
    return PageLengthHelpers.getPageLengthString(value);
  }
}
