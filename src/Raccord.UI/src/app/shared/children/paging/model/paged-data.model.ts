import { PageInfo } from './page-info.model';

export class PagedData<T> {
  public data: T[] = [];
  public pageInfo: PageInfo;
  public total: number;
  public full: boolean;

  constructor(obj?: {
    data: T[],
    pageInfo: PageInfo
  }) {
      if (obj) {
          this.data = obj.data;
          this.pageInfo = obj.pageInfo;
      }
  }
}
