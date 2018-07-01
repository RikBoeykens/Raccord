import { User } from './user.model';

export class UserSummary extends User {
  public hasImage: boolean;

  constructor(
    obj?: {
      ID: string,
      email: string,
      firstName: string,
      lastName: string,
      hasImage: boolean
    }
  ) {
    super(obj);
    this.hasImage = obj.hasImage;
  }
}
