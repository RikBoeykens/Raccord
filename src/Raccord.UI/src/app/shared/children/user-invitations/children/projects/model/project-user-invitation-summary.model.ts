import { BaseModel } from '../../../../..';
import { ProjectRole } from '../../../../users';

export class ProjectUserInvitationSummary extends BaseModel {
  public id: number;
  public projectRole: ProjectRole;

  constructor(
    obj?: {
      id: number,
      projectRole: ProjectRole
    }
  ) {
    super();
    if (obj) {
      this.id = obj.id;
      this.projectRole = obj.projectRole;
    }
  }
}
