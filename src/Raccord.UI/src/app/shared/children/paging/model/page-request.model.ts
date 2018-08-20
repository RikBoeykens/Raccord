export class PageRequest {
  public page: number;
  public pageSize: number;
  public full: boolean = false;

  constructor(obj?: {
    page: number,
    pageSize: number,
    full: boolean
  }) {
      if (obj) {
          this.page = obj.page;
          this.pageSize = obj.pageSize;
          this.full = obj.full;
      }
  }
}
