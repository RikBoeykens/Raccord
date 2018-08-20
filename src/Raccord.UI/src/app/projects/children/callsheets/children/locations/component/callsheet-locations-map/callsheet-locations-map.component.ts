
import { Input, Component, OnInit } from '@angular/core';
import { CallsheetLocation, CallsheetLocationSet } from '../../../../../..';
import { MapsHelpers, RouteSettings } from '../../../../../../../shared';
import { SceneSummary } from '../../../../../../../shared/children/scenes';

@Component({
  selector: 'callsheet-locations-map',
  templateUrl: 'callsheet-locations-map.component.html'
})
export class CallsheetLocationsMapComponent implements OnInit {
  @Input() public locations: CallsheetLocation[];
  @Input() public projectId: number;
  public bounds: any;
  public markerLocations: CallsheetLocation[] = [];
  public markerLocationSets: CallsheetLocationSet[] = [];

  public ngOnInit() {
    this.setBounds();
  }

  public getLocationLink(location: CallsheetLocation) {
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.LOCATIONS}/${location.id}`;
  }

  public getLocationSetLink(locationSet: CallsheetLocationSet) {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.LOCATIONSETS}/${locationSet.id}`;
  }

  public getSceneLink(scene: SceneSummary) {
    return `/${RouteSettings.PROJECTS}/${this.projectId}/${RouteSettings.SCENES}/${scene.id}`;
  }

  private setBounds() {
    this.markerLocations = this.locations.filter((l) => l.latLng.hasLatLng);
    this.markerLocations.forEach((location) => {
        this.markerLocationSets =
            this.markerLocationSets.concat(location.sets.filter((l) => l.latLng.hasLatLng));
    });
    if (this.markerLocations.length || this.markerLocationSets.length) {
        let latLngs = this.markerLocations.map((location) => location.latLng);
        latLngs =
            latLngs.concat(this.markerLocationSets.map((locationSet) => locationSet.latLng));
        this.bounds = MapsHelpers.getBounds(latLngs);
    }
  }
}
