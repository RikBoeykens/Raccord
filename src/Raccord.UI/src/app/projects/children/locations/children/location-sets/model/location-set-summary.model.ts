import { LatLng, BaseModel } from '../../../../../../shared';
import { ScriptLocation } from '../../../../../../shared/children/script-locations';
import { Location } from '../../../../..';

export class LocationSetSummary extends BaseModel {
    public id: number;
    public name: string;
    public description: string;
    public latLng: LatLng;
    public location: Location;
    public scriptLocation: ScriptLocation;

    constructor(
        obj?: {
        id: number,
        name: string,
        description: string,
        latLng: LatLng,
        location: Location,
        scriptLocation: ScriptLocation
    }) {
        super();
        if (obj) {
            this.id = obj.id;
            this.name = obj.name;
            this.description = obj.description;
            this.latLng = obj.latLng;
            this.location = obj.location;
            this.scriptLocation = obj.scriptLocation;
        } else {
            this.id = 0;
            this.latLng = new LatLng();
        }
    }
}
