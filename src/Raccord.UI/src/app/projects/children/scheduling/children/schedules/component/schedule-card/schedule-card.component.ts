import { Input, Component } from '@angular/core';
import { ScheduleSummary } from '../../../../../..';

@Component({
  selector: 'schedule-card',
  templateUrl: 'schedule-card.component.html'
})
export class ScheduleCardComponent {
  @Input() public schedule: ScheduleSummary;
}
