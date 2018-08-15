import { BaseModel } from '../../../../shared/model/base.model';
import { PagedData } from '../../../../shared/children/paging';
import { ScheduleCrewUnitSummary, CallsheetSummary } from '../../..';

export class SchedulingDashboard extends BaseModel {
  public schedules: PagedData<ScheduleCrewUnitSummary>;
  public callsheets: PagedData<CallsheetSummary>;

  constructor(
    obj?: {
      schedules: PagedData<ScheduleCrewUnitSummary>,
      callsheets: PagedData<CallsheetSummary>
  }) {
    super();
    if (obj) {
      this.schedules = obj.schedules;
      this.callsheets = obj.callsheets;
    }
  }
}
