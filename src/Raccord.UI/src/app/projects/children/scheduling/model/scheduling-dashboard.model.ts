import { BaseModel } from '../../../../shared/model/base.model';
import { PagedData } from '../../../../shared/children/paging';
import { ScheduleSummary, CallsheetSummary } from '../../..';

export class SchedulingDashboard extends BaseModel {
  public schedules: PagedData<ScheduleSummary>;
  public callsheets: PagedData<CallsheetSummary>;

  constructor(
    obj?: {
      schedules: PagedData<ScheduleSummary>,
      callsheets: PagedData<CallsheetSummary>
  }) {
    super();
    if (obj) {
      this.schedules = obj.schedules;
      this.callsheets = obj.callsheets;
    }
  }
}
