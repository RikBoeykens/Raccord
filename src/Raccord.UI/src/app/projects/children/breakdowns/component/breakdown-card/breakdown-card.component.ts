import { Input, Component } from '@angular/core';
import { BreakdownSummary } from '../../../..';

@Component({
  selector: 'breakdown-card',
  templateUrl: 'breakdown-card.component.html'
})
export class BreakdownCardComponent {
  @Input() public breakdown: BreakdownSummary;
}
