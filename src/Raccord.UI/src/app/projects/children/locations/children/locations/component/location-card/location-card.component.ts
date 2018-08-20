import { Input, Component } from '@angular/core';
import { LocationSummary } from '../../model/location-summary.model';

@Component({
  selector: 'location-card',
  templateUrl: 'location-card.component.html'
})
export class LocationCardComponent {
  @Input() public location: LocationSummary;
}
