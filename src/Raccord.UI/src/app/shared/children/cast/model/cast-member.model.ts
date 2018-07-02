import { BaseModel } from '../../..';

export class CastMember extends BaseModel {
  public id: number;
  public firstName: string;
  public lastName: string;
  public telephone: string;
  public email: string;
  public projectID: number;

  constructor(obj?: {
                      id: number,
                      firstName: string,
                      lastName: string,
                      telephone: string,
                      email: string,
                      projectID: number,
                  }) {
      super();
      if (obj) {
          this.id = obj.id;
          this.firstName = obj.firstName;
          this.lastName = obj.lastName;
          this.telephone = obj.telephone;
          this.email = obj.email;
          this.projectID = obj.projectID;
      } else {
          this.id = 0;
      }
  }
}
