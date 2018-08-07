import { Component, Input } from '@angular/core';
import { LocationSetLocation } from '../../../../../../../..';

@Component({
  selector: 'scrpt-location-location-sets',
  templateUrl: 'script-location-location-sets.component.html',
})
export class ScriptLocationLocationSetsComponent {
  @Input() public locationSets: LocationSetLocation[];
  @Input() public projectId: number;
}
