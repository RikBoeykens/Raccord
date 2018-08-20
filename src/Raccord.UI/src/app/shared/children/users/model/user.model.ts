import { BaseModel } from '../../../model/base.model';

export class User extends BaseModel {
  public id: string;
  public email: string;
  public firstName: string;
  public lastName: string;

  constructor(
    obj?: {
      id: string,
      email: string,
      firstName: string,
      lastName: string
    }
  ) {
    super();
    if (obj) {
      this.id = obj.id,
      this.email = obj.email;
      this.firstName = obj.firstName;
      this.lastName = obj.lastName;
    }
  }
}
