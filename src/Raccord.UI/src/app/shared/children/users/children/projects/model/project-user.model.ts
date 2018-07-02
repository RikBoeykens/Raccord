import { BaseModel } from '../../../../..';

export class ProjectUser extends BaseModel {
  public id: number;
  public projectID: number;
  public userID: string;
  public roleID?: number;

  constructor(obj?: {
    id: number,
    projectID: number,
    userID: string,
    roleID?: number
  }) {
    super();
    if (obj) {
      this.id = obj.id;
      this.projectID = obj.projectID;
      this.userID = obj.userID;
      this.roleID = obj.roleID;
    }
  }
}
