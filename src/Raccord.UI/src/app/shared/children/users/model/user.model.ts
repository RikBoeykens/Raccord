import { BaseModel } from '../../../model/base.model';

export class User extends BaseModel {
  public ID: string;
  public email: string;
  public firstName: string;
  public lastName: string;

  constructor(
    obj?: {
      ID: string,
      email: string,
      firstName: string,
      lastName: string
    }
  ) {
    super();
    if (obj) {
      this.ID = obj.ID,
      this.email = obj.email;
      this.firstName = obj.firstName;
      this.lastName = obj.lastName;
    }
  }
}
