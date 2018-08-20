import { BaseModel } from '..';

export class LatLng extends BaseModel {
  public latitude?: number;
  public longitude?: number;
  public hasLatLng: boolean;

  constructor(obj?: {
    latitude?: number,
    longitude?: number,
    hasLatLng: boolean
  }) {
    super();
    if (obj) {
      this.latitude = obj.latitude;
      this.longitude = obj.longitude;
      this.hasLatLng = obj.hasLatLng;
    } else {
      this.hasLatLng = false;
    }
  }
}
