
import { Input, Component, OnInit } from '@angular/core';
import { RouteSettings, MapsHelpers } from '../../../../../../../shared';
import { LocationSummary } from '../../../../../..';

@Component({
  selector: 'locations-list-map',
  templateUrl: 'locations-list-map.component.html'
})
export class LocationsListMapComponent implements OnInit {
  @Input() public locations: LocationSummary[];
  @Input() public projectId: number;
  public bounds: any;
  public markerLocations: LocationSummary[] = [];

  public ngOnInit() {
    this.setBounds();
  }

  public getLocationLink(location: LocationSummary) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.LOCATIONS}/${location.id}`;
  }

  private setBounds() {
    this.markerLocations = this.locations.filter((l) => l.latLng.hasLatLng);
    if (this.markerLocations.length) {
      let latLngs = this.markerLocations.map((location) => location.latLng);
      latLngs =
          latLngs.concat();
      this.bounds = MapsHelpers.getBounds(latLngs);
    }
  }
}
