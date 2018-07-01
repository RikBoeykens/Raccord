import { BaseModel } from '../../../../../model/base.model';
import { UserSummary } from '../../../model/user-summary.model';
import { ProjectRole } from '../../..';

export class ProjectUserUser extends BaseModel {
  public ID: number;
  public userSummary: UserSummary;
  public projectRole: ProjectRole;

  constructor(
    obj?: {
      ID: number,
      userSummary: UserSummary
    }
  ) {
    super();
    this.ID = obj.ID;
    this.userSummary = obj.userSummary;
  }
}
