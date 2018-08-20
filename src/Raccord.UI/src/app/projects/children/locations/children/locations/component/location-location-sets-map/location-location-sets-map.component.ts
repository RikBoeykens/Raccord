
import { Input, Component, OnInit } from '@angular/core';
import { RouteSettings, MapsHelpers } from '../../../../../../../shared';
import { FullLocation, LocationSetScriptLocation, Location } from '../../../../../..';

@Component({
  selector: 'location-location-sets-map',
  templateUrl: 'location-location-sets-map.component.html'
})
export class LocationLocationSetsMapComponent implements OnInit {
  @Input() public location: FullLocation;
  @Input() public projectId: number;
  public bounds: any;
  public markerLocation: Location;
  public markerLocationSets: LocationSetScriptLocation[] = [];

  public ngOnInit() {
    this.setBounds();
  }

  public getLocationSetLink(locationSet: LocationSetScriptLocation) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.LOCATIONSETS}/${locationSet.id}`;
  }

  private setBounds() {
    this.markerLocation = this.location.latLng.hasLatLng ? new Location(this.location) : null;
    this.markerLocationSets = this.location.sets.filter((l) => l.latLng.hasLatLng);
    if (this.markerLocation || this.markerLocationSets.length) {
      let latLngs = [this.markerLocation.latLng];
      latLngs =
          latLngs.concat(this.markerLocationSets.map((locationSet) => locationSet.latLng));
      this.bounds = MapsHelpers.getBounds(latLngs);
    }
  }
}
