import { BaseModel } from '../../../../../model/base.model';
import { UserSummary } from '../../../model/user-summary.model';
import { ProjectRole } from '../../..';

export class ProjectUserUser extends BaseModel {
  public ID: number;
  public user: UserSummary;
  public projectRole: ProjectRole;

  constructor(
    obj?: {
      ID: number,
      user: UserSummary,
      projectRole: ProjectRole
    }
  ) {
    super();
    this.ID = obj.ID;
    this.user = obj.user;
    this.projectRole = obj.projectRole;
  }
}
