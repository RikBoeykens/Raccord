import { PageRequest } from '../model/page-request.model';

export class PageRequestHelpers {
  public static ConstructParams(request: PageRequest): string {
      if (request === null || request.full) {
        return '';
      }
      return `pageSize=${request.pageSize}&page=${request.page}&full=${request.full}`;
  }
}
