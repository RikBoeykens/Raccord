import { UserInvitationSummary } from '../../../../shared/children/user-invitations';

export class AdminUserInvitationSummary extends UserInvitationSummary {
  public projectCount: number;

  constructor(obj?: {
    id: string,
    email: string,
    firstName: string,
    lastName: string,
    acceptedDate?: Date,
    projectCount: number
  }) {
    super(obj);
    if (obj) {
      this.projectCount = obj.projectCount;
    }
  }
}
