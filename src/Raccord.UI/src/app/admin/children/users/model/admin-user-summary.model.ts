import { UserSummary } from '../../../../shared/children/users';

export class AdminUserSummary extends UserSummary {
  public projectCount: number;

  constructor(
    obj?: {
      id: string,
      email: string,
      firstName: string,
      lastName: string,
      hasImage: boolean,
      projectCount: number
    }
  ) {
    super(obj);
    this.projectCount = obj.projectCount;
  }
}
