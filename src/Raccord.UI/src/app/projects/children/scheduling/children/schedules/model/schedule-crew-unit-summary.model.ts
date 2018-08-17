import { CrewUnit } from '../../../../../../shared/children/crew';
import { ScheduleSummary } from './schedule-summary.model';

export class ScheduleCrewUnitSummary extends ScheduleSummary {

  public crewUnit: CrewUnit;

  constructor(
    obj?: {
      startDate: Date,
      endDate: Date,
      crewUnit: CrewUnit
    }
  ) {
    super(obj);
    this.crewUnit = obj.crewUnit;
  }
}
