import { User } from './user.model';

export class FullUser extends User {
  public hasImage: boolean;

  constructor(
    obj?: {
      id: string,
      email: string,
      firstName: string,
      lastName: string,
      hasImage: boolean
    }
  ) {
    super();
    if (obj) {
      this.id = obj.id,
      this.email = obj.email;
      this.firstName = obj.firstName;
      this.lastName = obj.lastName;
      this.hasImage = obj.hasImage;
    }
  }
}
