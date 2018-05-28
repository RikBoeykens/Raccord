import { UserInvitation } from './user-invitation.model';
import { ProjectUserInvitationSummary } from
  '../../admin/invitations/children/project/model/project-user-invitation-summary.model';

export class FullUserInvitation extends UserInvitation {
  public acceptedDate?: Date;
  public projects: ProjectUserInvitationSummary[];

  constructor(obj?: {
    id: string,
    email: string,
    firstName: string,
    lastName: string,
    acceptedDate?: Date,
    projects: ProjectUserInvitationSummary[]
  }) {
    super(obj);
    if (obj) {
      this.acceptedDate = obj.acceptedDate;
      this.projects = obj.projects;
    }
  }
}
