import { UserSummary } from '../../../model/user-summary.model';
import { ProjectRole } from '../../..';
import { ProjectUserUser } from './project-user-user.model';

export class LinkedProjectUserUser extends ProjectUserUser {
  public linkID: number;

  constructor(
    obj?: {
      id: number,
      user: UserSummary,
      projectRole: ProjectRole,
      linkID: number
    }
  ) {
    super(obj);
    if (obj) {
      this.linkID = obj.linkID;
    }
  }
}
