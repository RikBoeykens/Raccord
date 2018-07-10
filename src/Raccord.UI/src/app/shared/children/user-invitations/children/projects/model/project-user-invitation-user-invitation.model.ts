import { ProjectUserInvitationSummary, UserInvitation } from '../../..';
import { ProjectRole } from '../../../../users';

export class ProjectUserInvitationUserInvitation extends ProjectUserInvitationSummary {
  public userInvitation: UserInvitation;

  constructor(
    obj?: {
      id: number,
      projectRole: ProjectRole,
      userInvitation: UserInvitation
    }
  ) {
    super(obj);
    if (obj) {
      this.userInvitation = obj.userInvitation;
    }
  }
}
