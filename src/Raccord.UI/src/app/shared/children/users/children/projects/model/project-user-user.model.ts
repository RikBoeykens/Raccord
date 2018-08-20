import { BaseModel } from '../../../../../model/base.model';
import { UserSummary } from '../../../model/user-summary.model';
import { ProjectRole } from '../../..';

export class ProjectUserUser extends BaseModel {
  public id: number;
  public user: UserSummary;
  public projectRole: ProjectRole;

  constructor(
    obj?: {
      id: number,
      user: UserSummary,
      projectRole: ProjectRole
    }
  ) {
    super();
    this.id = obj.id;
    this.user = obj.user;
    this.projectRole = obj.projectRole;
  }
}
