import { Input, Component } from '@angular/core';
import { BreakdownItemSummary } from '../../../../../..';

@Component({
  selector: 'breakdown-item-card',
  templateUrl: 'breakdown-item-card.component.html'
})
export class BreakdownItemCardComponent {
  @Input() public breakdownItem: BreakdownItemSummary;
}
