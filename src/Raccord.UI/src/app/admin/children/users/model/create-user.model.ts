import { User } from '../../../../shared/children/users';

export class CreateUser extends User {
  public password: string;

  constructor(
    obj?: {
      ID: string,
      email: string,
      firstName: string,
      lastName: string,
      password: string
    }
  ) {
    super(obj);
    if (obj) {
      this.password = obj.password;
    }
  }
}
