import { Input, Component } from '@angular/core';
import { ScriptLocationSummary } from '../..';

@Component({
  selector: 'scrpt-location-card',
  templateUrl: 'script-location-card.component.html'
})
export class ScriptLocationCardComponent {
  @Input() public scriptLocation: ScriptLocationSummary;
}
