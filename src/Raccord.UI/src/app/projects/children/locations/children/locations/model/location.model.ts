import { BaseModel, Address, LatLng } from '../../../../../../shared';

export class Location extends BaseModel {
  public id: number;
  public name: string;
  public description: string;
  public address: Address;
  public latLng: LatLng;
  public projectID: number;

  constructor(
    obj?: {
      id: number,
      name: string,
      description: string,
      address: Address,
      latLng: LatLng,
      projectID: number
  }) {
    super();
    if (obj) {
      this.id = obj.id;
      this.name = obj.name;
      this.description = obj.description;
      this.address = obj.address;
      this.latLng = obj.latLng;
      this.projectID = obj.projectID;
    } else {
      this.id = 0;
      this.address = new Address();
      this.latLng = new LatLng();
    }
  }
}
