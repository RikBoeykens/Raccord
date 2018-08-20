export class SortOrder {
  public parentId: number;
  public sortIds: number[];

  constructor(obj?: {parentId: number, sortIds: number[]}) {
    if (obj) {
      this.parentId = obj.parentId;
      this.sortIds = obj.sortIds;
    }
  }
}
