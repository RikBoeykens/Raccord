import { Input, Component } from '@angular/core';
import { SlateSummary } from '../../../../..';

@Component({
  selector: 'slate-card',
  templateUrl: 'slate-card.component.html'
})
export class SlateCardComponent {
  @Input() public slate: SlateSummary;
}
