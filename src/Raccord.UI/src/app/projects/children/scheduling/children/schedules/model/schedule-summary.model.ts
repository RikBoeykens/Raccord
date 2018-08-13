import { BaseModel } from '../../../../../../shared';
import { CrewUnit } from '../../../../../../shared/children/crew';

export class ScheduleSummary extends BaseModel {
  public startDate: Date;
  public endDate: Date;
  public crewUnit: CrewUnit;

  constructor(
    obj?: {
      startDate: Date,
      endDate: Date,
      crewUnit: CrewUnit
    }
  ) {
    super();
    this.startDate = obj.startDate;
    this.endDate = obj.endDate;
    this.crewUnit = obj.crewUnit;
  }
}
