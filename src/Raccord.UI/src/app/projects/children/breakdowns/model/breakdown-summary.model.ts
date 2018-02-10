import { Breakdown } from './breakdown.model';
import { UserProfile } from '../../../../profile/model/user-profile.model';

export class BreakdownSummary extends Breakdown {
  public createdBy: UserProfile;

  constructor(obj?: {
                      id: number,
                      name: string,
                      description: string,
                      projectID: number,
                      createdBy: UserProfile
                  }) {
    super(obj);
    if (obj) {
      this.createdBy = obj.createdBy;
    }
  }
}
