import { Input, Component } from '@angular/core';
import { ShootingDayCrewUnit } from '../../../../../..';

@Component({
  selector: 'shooting-day-crew-unit-card',
  templateUrl: 'shooting-day-crew-unit-card.component.html'
})
export class ShootingDayCrewUnitCardComponent {
  @Input() public shootingDay: ShootingDayCrewUnit;
}
