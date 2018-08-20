import { Input, Component } from '@angular/core';
import { ScheduleCrewUnitSummary } from '../../../../../..';

@Component({
  selector: 'schedule-crew-unit-card',
  templateUrl: 'schedule-crew-unit-card.component.html'
})
export class ScheduleCrewUnitCardComponent {
  @Input() public schedule: ScheduleCrewUnitSummary;
}
