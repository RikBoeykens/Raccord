
import { Input, Component, OnInit } from '@angular/core';
import { RouteSettings, MapsHelpers } from '../../../../../../../shared';
import { FullLocationSet, Location, LocationSetSummary } from '../../../../../..';

@Component({
  selector: 'location-set-landing-map',
  templateUrl: 'location-set-landing-map.component.html'
})
export class LocationSetLandingMapComponent implements OnInit {
  @Input() public locationSet: FullLocationSet;
  @Input() public projectId: number;
  public bounds: any;
  public markerLocation: Location;
  public markerLocationSet: LocationSetSummary;

  public ngOnInit() {
    this.setBounds();
  }

  public getLocationLink() {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.LOCATIONS}/${this.locationSet.location.id}`;
  }

  private setBounds() {
    this.markerLocation = this.locationSet.location.latLng.hasLatLng ?
      new Location(this.locationSet.location) : null;
    this.markerLocationSet = this.locationSet.latLng.hasLatLng ?
    new LocationSetSummary(this.locationSet) : null;
    if (this.markerLocation || this.markerLocationSet) {
      const latLngs = [];
      if (this.markerLocation) {
        latLngs.push(this.markerLocation.latLng);
      }
      if (this.markerLocationSet) {
        latLngs.push(this.markerLocationSet.latLng);
      }
      this.bounds = MapsHelpers.getBounds(latLngs);
    }
  }
}
