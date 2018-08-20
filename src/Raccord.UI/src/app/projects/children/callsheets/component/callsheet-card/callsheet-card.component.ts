import { Input, Component } from '@angular/core';
import { CallsheetSummary } from '../../../..';

@Component({
  selector: 'callsheet-card',
  templateUrl: 'callsheet-card.component.html'
})
export class CallsheetCardComponent {
  @Input() public callsheet: CallsheetSummary;
}
