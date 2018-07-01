import { ProjectUserInvitationSummary } from './project-user-invitation-summary.model';
import { UserInvitation } from './user-invitation.model';
import { ProjectRole } from '../../..';

export class ProjectUserInvitationUserInvitation extends ProjectUserInvitationSummary {
  public userInvitation: UserInvitation;

  constructor(
    obj?: {
      ID: number,
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
