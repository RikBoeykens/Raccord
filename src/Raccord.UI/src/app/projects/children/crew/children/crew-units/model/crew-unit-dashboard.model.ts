import { BaseModel } from '../../../../../../shared/model/base.model';
import { PagedData } from '../../../../../../shared/children/paging';
import { ScheduleSummary, CallsheetSummary } from '../../../../..';
import { CrewUnit } from '../../../../../../shared/children/crew';

export class CrewUnitDashboard extends BaseModel {
  public crewUnit: CrewUnit;
  public schedules: PagedData<ScheduleSummary>;
  public callsheets: PagedData<CallsheetSummary>;

  constructor(
    obj?: {
      crewUnit: CrewUnit,
      schedules: PagedData<ScheduleSummary>,
      callsheets: PagedData<CallsheetSummary>
  }) {
    super();
    if (obj) {
      this.crewUnit = obj.crewUnit;
      this.schedules = obj.schedules;
      this.callsheets = obj.callsheets;
    }
  }
}
