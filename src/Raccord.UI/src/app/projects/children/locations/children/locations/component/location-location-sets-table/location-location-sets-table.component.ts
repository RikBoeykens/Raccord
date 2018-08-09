import { Component, Input } from '@angular/core';
import { LocationSetScriptLocation } from '../../../../../..';
import { RouteSettings } from '../../../../../../../shared';

@Component({
  selector: 'location-location-sets-table',
  templateUrl: 'location-location-sets-table.component.html',
})
export class LocationLocationSetsTableComponent {
  @Input() public locationSets: LocationSetScriptLocation[];
  @Input() public projectId: number;
  public displayedColumns = [
    'image',
    'set',
    'scriptlocation'
  ];

  public getLocationSetLink(locationSet: LocationSetScriptLocation): string {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.LOCATIONSETS}/${locationSet.id}`;
  }

  public getScriptLocationLink(locationSet: LocationSetScriptLocation): string {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.SCRIPTLOCATIONS}/${locationSet.scriptLocation.id}`;
  }
}
