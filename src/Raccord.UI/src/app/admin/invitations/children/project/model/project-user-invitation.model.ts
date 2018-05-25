import { BaseModel } from '../../../../../shared';

export class ProjectUserInvitation extends BaseModel {
  public id: number;
  public userInvitationID: string;
  public projectID: number;
  public roleID?: number;

  constructor(obj?: {
    id: number,
    userInvitationID: string,
    projectID: number,
    roleID?: number
  }) {
    super();
    if (obj) {
      this.id = obj.id;
      this.userInvitationID = obj.userInvitationID;
      this.projectID = obj.projectID;
      this.roleID = obj.roleID;
    }
  }
}
