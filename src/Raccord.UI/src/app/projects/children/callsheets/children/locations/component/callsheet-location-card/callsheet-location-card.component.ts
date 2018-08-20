
import { Input, Component } from '@angular/core';
import { CallsheetLocation } from '../../model/callsheet-location.model';
import { RouteSettings } from '../../../../../../../shared';

@Component({
  selector: 'callsheet-location-card',
  templateUrl: 'callsheet-location-card.component.html'
})
export class CallsheetLocationCardComponent {
  @Input() public location: CallsheetLocation;

  public getLocationLink() {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.PROJECTS}/${this.location.projectID}/${RouteSettings.LOCATIONS}/${this.location.id}`;
  }
}
