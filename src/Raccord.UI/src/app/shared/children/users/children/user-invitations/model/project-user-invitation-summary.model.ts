import { BaseModel } from '../../../../..';
import { ProjectRole } from '../../..';

export class ProjectUserInvitationSummary extends BaseModel {
  public ID: number;
  public projectRole: ProjectRole;

  constructor(
    obj?: {
      ID: number,
      projectRole: ProjectRole
    }
  ) {
    super();
    if (obj) {
      this.ID = obj.ID;
      this.projectRole = obj.projectRole;
    }
  }
}
