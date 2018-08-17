import { BaseModel } from '../../../../shared/model/base.model';
import { PagedData } from '../../../../shared/children/paging';
import { ScheduleCrewUnitSummary, CallsheetCrewUnit } from '../../..';

export class SchedulingDashboard extends BaseModel {
  public schedules: PagedData<ScheduleCrewUnitSummary>;
  public callsheets: PagedData<CallsheetCrewUnit>;

  constructor(
    obj?: {
      schedules: PagedData<ScheduleCrewUnitSummary>,
      callsheets: PagedData<CallsheetCrewUnit>
  }) {
    super();
    if (obj) {
      this.schedules = obj.schedules;
      this.callsheets = obj.callsheets;
    }
  }
}
