import { BaseModel } from '../../../../../shared';
import { Address } from '../../../../../shared';
import { LatLng } from '../../../../../shared';

export class LocationSet extends BaseModel{
    id: number;
    name: string;
    description: string;
    latLng: LatLng;
    locationId: number;
    scriptLocationId: number;

    constructor(obj?: {
                        id: number, 
                        name: string,
                        description: string,
                        latLng: LatLng,
                        locationId: number, 
                        scriptLocationId: number
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.name = obj.name;
            this.description = obj.description;
            this.latLng = obj.latLng;
            this.locationId = obj.locationId;
            this.scriptLocationId = obj.scriptLocationId;
        }
        else{
            this.id = 0;
            this.latLng = new LatLng();
        }
    }
}