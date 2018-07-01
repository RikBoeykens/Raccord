import { FullProject } from '../../../../shared/children/projects';
import {
  ProjectUserUser,
  ProjectUserInvitationUserInvitation
} from '../../../../shared/children/users';
import { Image } from '../../../../shared/children/images';

export class AdminFullProject extends FullProject {
  public users: ProjectUserUser[];
  public invitations: ProjectUserInvitationUserInvitation[];

  constructor(
    obj?: {
      id: number,
      title: string,
      primaryImage: Image,
      users: ProjectUserUser[],
      invitations: ProjectUserInvitationUserInvitation[]
   }
  ) {
    super(obj);
    if (obj) {
      this.users = obj.users;
      this.invitations = obj.invitations;
    }
  }
}
