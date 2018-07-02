import { User } from '../../../../shared/children/users';

export class FullUser extends User {
  constructor(
    obj?: {
      ID: string,
      email: string,
      firstName: string,
      lastName: string
    }
  ) {
    super(obj);
  }
}
