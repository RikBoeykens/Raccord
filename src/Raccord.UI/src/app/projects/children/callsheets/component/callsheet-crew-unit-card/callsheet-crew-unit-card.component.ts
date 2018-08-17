import { Input, Component } from '@angular/core';
import { CallsheetCrewUnit } from '../../../..';

@Component({
  selector: 'callsheet-crew-unit-card',
  templateUrl: 'callsheet-crew-unit-card.component.html'
})
export class CallsheetCrewUnitCardComponent {
  @Input() public callsheet: CallsheetCrewUnit;
}
