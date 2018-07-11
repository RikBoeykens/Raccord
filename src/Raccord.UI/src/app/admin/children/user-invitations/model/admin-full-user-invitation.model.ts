import {
  FullUserInvitation,
  ProjectUserInvitationProject
} from '../../../../shared/children/user-invitations';

export class AdminFullUserInvitation extends FullUserInvitation {

  constructor(obj?: {
    id: string,
    email: string,
    firstName: string,
    lastName: string,
    acceptedDate?: Date,
    projects: ProjectUserInvitationProject[]
  }) {
    super(obj);
  }
}
