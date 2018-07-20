import { BaseModel } from '../../../../../shared';

export class CreateCrewUnitMemberCrewMember extends BaseModel {
  public linkID: number;
  public jobTitle: string;
  public departmentID: number;

  constructor(obj?: {
    linkID: number,
    jobTitle: string,
    departmentID: number
  }) {
      super();
      if (obj) {
          this.linkID = obj.linkID;
          this.jobTitle = obj.jobTitle;
          this.departmentID = obj.departmentID;
      }
  }
}
