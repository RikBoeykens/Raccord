import { BaseModel, LatLng } from '../../../../../../shared';
import { ScriptLocation } from '../../../../../../shared/children/script-locations';

export class LocationSetScriptLocation extends BaseModel {
    public id: number;
    public name: string;
    public description: string;
    public latLng: LatLng;
    public scriptLocation: ScriptLocation;

    constructor(
        obj?: {
        id: number,
        name: string,
        description: string,
        latLng: LatLng,
        scriptLocation: ScriptLocation
    }) {
        super();
        if (obj) {
            this.id = obj.id;
            this.name = obj.name;
            this.description = obj.description;
            this.latLng = obj.latLng;
            this.scriptLocation = obj.scriptLocation;
        } else {
            this.id = 0;
            this.latLng = new LatLng();
        }
    }
}
