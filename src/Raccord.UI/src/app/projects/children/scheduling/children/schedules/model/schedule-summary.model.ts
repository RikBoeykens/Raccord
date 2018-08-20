import { BaseModel } from '../../../../../../shared';

export class ScheduleSummary extends BaseModel {
  public startDate: Date;
  public endDate: Date;

  constructor(
    obj?: {
      startDate: Date,
      endDate: Date
    }
  ) {
    super();
    this.startDate = obj.startDate;
    this.endDate = obj.endDate;
  }
}
