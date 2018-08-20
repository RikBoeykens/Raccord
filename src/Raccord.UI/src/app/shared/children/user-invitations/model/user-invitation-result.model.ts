import { BaseModel } from '../../..';

export class UserInvitationResult extends BaseModel {
  public id: string;
  constructor(obj?: {
    id: string
  }) {
    super();
    if (obj) {
      this.id = obj.id;
    }
  }
}
