import { BaseModel } from '../../shared/model/base.model';
import { LatLng } from '../../shared';

export class Marker extends BaseModel {
  public label: string;
  public infoWindow: string;
  public latLng: LatLng;

  constructor(obj?: {
    label: string,
    infoWindow: string,
    latLng: LatLng
  }) {
    super();
    if (obj) {
      this.label = obj.label;
      this.infoWindow = obj.infoWindow;
      this.latLng = obj.latLng;
    }
  }
}
