import { BaseModel } from '../../shared';

export class CreateUserFromInvitation extends BaseModel {
  public id: string;
  public firstName: string;
  public lastName: string;
  public email: string;
  public password: string;
  constructor(obj?: {
    id: string,
    firstName: string,
    lastName: string,
    email: string,
    password: string,
  }) {
    super();
    if (obj) {
      this.id = obj.id;
      this.firstName = obj.firstName;
      this.lastName = obj.lastName;
      this.email = obj.email;
      this.password = obj.password;
    }
  }
}
