import { BaseModel } from '../../shared/model/base.model';
import { LatLng } from '../../shared';

export class GeocodingResponse extends BaseModel {
  public formattedAddress: string;
  public latLng: LatLng;

  constructor(obj?: {
    formattedAddress: string,
    latLng: LatLng
  }) {
    super();
    if (obj) {
      this.formattedAddress = obj.formattedAddress;
      this.latLng = obj.latLng;
    }
  }
}
