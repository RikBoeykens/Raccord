import { UserInvitation } from './user-invitation.model';

export class UserInvitationSummary extends UserInvitation {
  public acceptedDate?: Date;
  constructor(obj?: {
    id: string,
    email: string,
    firstName: string,
    lastName: string,
    acceptedDate?: Date
  }) {
    super(obj);
    if (obj) {
      this.acceptedDate = obj.acceptedDate;
    }
  }
}
