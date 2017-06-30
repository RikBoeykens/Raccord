import { BaseModel } from '../../../../../shared';
import { Address } from '../../../../../shared';
import { LatLng } from '../../../../../shared';
import { Location } from "../../";
import { ScriptLocation } from "../../../../children/script-locations/model/script-location.model";

export class LocationSetSummary extends BaseModel{
    id: number;
    name: string;
    description: string;
    latLng: LatLng;
    location: Location;
    scriptLocation: ScriptLocation;

    constructor(obj?: {
                        id: number, 
                        name: string,
                        description: string,
                        latLng: LatLng,
                        location: Location, 
                        scriptLocation: ScriptLocation
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.name = obj.name;
            this.description = obj.description;
            this.latLng = obj.latLng;
            this.location = obj.location;
            this.scriptLocation = obj.scriptLocation;
        }
        else{
            this.id = 0;
            this.latLng = new LatLng();
        }
    }
}