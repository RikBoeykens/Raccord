import { BaseModel, LatLng } from '../../../../../../shared';

export class LocationSet extends BaseModel {
  public id: number;
  public name: string;
  public description: string;
  public latLng: LatLng;
  public locationID: number;
  public scriptLocationID: number;

  constructor(
    obj?: {
      id: number,
      name: string,
      description: string,
      latLng: LatLng,
      locationID: number,
      scriptLocationID: number
  }) {
    super();
    if (obj) {
      this.id = obj.id;
      this.name = obj.name;
      this.description = obj.description;
      this.latLng = obj.latLng;
      this.locationID = obj.locationID;
      this.scriptLocationID = obj.scriptLocationID;
    } else {
      this.id = 0;
      this.latLng = new LatLng();
    }
  }
}
