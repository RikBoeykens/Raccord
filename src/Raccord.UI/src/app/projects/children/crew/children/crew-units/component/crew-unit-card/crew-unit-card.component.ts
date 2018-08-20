import { Input, Component } from '@angular/core';
import { CrewUnitSummary } from '../../../../../../../shared/children/crew';

@Component({
  selector: 'crew-unit-card',
  templateUrl: 'crew-unit-card.component.html'
})
export class CrewUnitCardComponent {
  @Input() public crewUnit: CrewUnitSummary;
}
