import { BaseModel } from '../../../../shared/model/base.model';
import { PagedData } from '../../../../shared/children/paging';
import { ScheduleCrewUnitSummary, CallsheetCrewUnit, ShootingDayCrewUnit } from '../../..';

export class SchedulingDashboard extends BaseModel {
  public schedules: PagedData<ScheduleCrewUnitSummary>;
  public callsheets: PagedData<CallsheetCrewUnit>;
  public shootingDays: PagedData<ShootingDayCrewUnit>;

  constructor(
    obj?: {
      schedules: PagedData<ScheduleCrewUnitSummary>,
      callsheets: PagedData<CallsheetCrewUnit>,
      shootingDays: PagedData<ShootingDayCrewUnit>
  }) {
    super();
    if (obj) {
      this.schedules = obj.schedules;
      this.callsheets = obj.callsheets;
      this.shootingDays = obj.shootingDays;
    }
  }
}
