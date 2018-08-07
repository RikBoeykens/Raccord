import { BaseModel, LatLng } from '../../../../../../shared';
import { Location } from '../../../../..';

export class LocationSetLocation extends BaseModel {
    public id: number;
    public name: string;
    public description: string;
    public latLng: LatLng;
    public location: Location;

    constructor(
        obj?: {
            id: number,
            name: string,
            description: string,
            latLng: LatLng,
            location: Location,
    }) {
        super();
        if (obj) {
            this.id = obj.id;
            this.name = obj.name;
            this.description = obj.description;
            this.latLng = obj.latLng;
            this.location = obj.location;
        } else {
            this.id = 0;
            this.latLng = new LatLng();
        }
    }
}
