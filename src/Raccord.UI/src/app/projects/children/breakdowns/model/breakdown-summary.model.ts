import { Breakdown } from './breakdown.model';
import { UserProfile } from '../../../../shared/children/users';

export class BreakdownSummary extends Breakdown {
  public createdBy: UserProfile;
  public selected: boolean;
  public isPublished: boolean;
  public isDefault: boolean;

  constructor(obj?: {
                      id: number,
                      name: string,
                      description: string,
                      projectID: number,
                      createdBy: UserProfile,
                      selected: boolean,
                      isPublished: boolean,
                      isDefault: boolean
                  }) {
    super(obj);
    if (obj) {
      this.createdBy = obj.createdBy;
      this.selected = obj.selected;
      this.isPublished = obj.isPublished;
      this.isDefault = obj.isDefault;
    }
  }
}
