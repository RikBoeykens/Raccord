
import { Input, Component, OnInit } from '@angular/core';
import { LocationSetLocation, Location } from '../../../../../../../..';
import { RouteSettings, MapsHelpers } from '../../../../../../../../../shared';

@Component({
  selector: 'scrpt-location-location-sets-map',
  templateUrl: 'script-location-location-sets-map.component.html'
})
export class ScriptLocationLocationSetsMapComponent implements OnInit {
  @Input() public locationSets: LocationSetLocation[];
  @Input() public projectId: number;
  public bounds: any;
  public markerLocations: Location[] = [];
  public markerLocationSets: LocationSetLocation[] = [];

  public ngOnInit() {
    this.setBounds();
  }

  public getLocationLink(location: Location) {
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.LOCATIONS}/${location.id}`;
  }

  public getLocationSetLink(locationSet: LocationSetLocation) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.LOCATIONSETS}/${locationSet.id}`;
  }

  private setBounds() {
    this.markerLocationSets = this.locationSets.filter((l) => l.latLng.hasLatLng);
    this.locationSets.forEach((locationSet) => {
      if (locationSet.location.latLng.hasLatLng) {
        this.markerLocations.push(locationSet.location);
      }
    });
    if (this.markerLocations.length || this.markerLocationSets.length) {
      let latLngs = this.markerLocations.map((location) => location.latLng);
      latLngs =
          latLngs.concat(this.markerLocationSets.map((locationSet) => locationSet.latLng));
      this.bounds = MapsHelpers.getBounds(latLngs);
    }
  }
}
