import { UserInvitation } from './user-invitation.model';
import { ProjectUserInvitationProject } from '..';

export class FullUserInvitation extends UserInvitation {
  public acceptedDate?: Date;
  public projects: ProjectUserInvitationProject[];

  constructor(obj?: {
    id: string,
    email: string,
    firstName: string,
    lastName: string,
    acceptedDate?: Date,
    projects: ProjectUserInvitationProject[]
  }) {
    super(obj);
    if (obj) {
      this.acceptedDate = obj.acceptedDate;
      this.projects = obj.projects;
    }
  }
}
