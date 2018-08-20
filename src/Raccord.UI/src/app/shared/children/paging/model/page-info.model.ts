export class PageInfo {
  public page: number;
  public pageSize: number;
  public total: number;
  public full: boolean;

  constructor(obj?: {
    page: number,
    pageSize: number,
    total: number,
    full: boolean
  }) {
      if (obj) {
          this.page = obj.page;
          this.pageSize = obj.pageSize;
          this.total = obj.total;
          this.full = obj.full;
      }
  }
}
