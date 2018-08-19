import { Input, Component } from '@angular/core';
import { ShootingDaySummary } from '../../../../../..';

@Component({
  selector: 'shooting-day-card',
  templateUrl: 'shooting-day-card.component.html'
})
export class ShootingDayCardComponent {
  @Input() public shootingDay: ShootingDaySummary;
}
