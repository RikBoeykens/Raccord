import { Input, Component } from '@angular/core';
import { BreakdownTypeSummary } from '../../../../../..';

@Component({
  selector: 'breakdown-type-card',
  templateUrl: 'breakdown-type-card.component.html'
})
export class BreakdownTypeCardComponent {
  @Input() public breakdownType: BreakdownTypeSummary;
}
