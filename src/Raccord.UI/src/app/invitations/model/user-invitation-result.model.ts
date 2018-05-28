import { BaseModel } from '../../shared';

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
