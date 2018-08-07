import { Component, Input } from '@angular/core';
import { RouteSettings } from '../../../../../../../../../shared';
import { LocationSetLocation } from '../../../../../../../..';

@Component({
  selector: 'scrpt-location-location-sets-table',
  templateUrl: 'script-location-location-sets-table.component.html',
})
export class ScriptLocationLocationSetsTableComponent {
  @Input() public locationSets: LocationSetLocation[];
  @Input() public projectId: number;
  public displayedColumns = [
    'image',
    'set',
    'location'
  ];

  public getLocationSetLink(locationSet: LocationSetLocation): string {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.LOCATIONSETS}/${locationSet.id}`;
  }

  public getLocationLink(locationSet: LocationSetLocation): string {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.LOCATIONS}/${locationSet.location.id}`;
  }
}
