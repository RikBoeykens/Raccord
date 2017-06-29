import { BaseModel } from '../../../../../shared';
import { Address } from '../../../../../shared';
import { LatLng } from '../../../../../shared';
import { Location } from "../../";

export class LocationSetLocation extends BaseModel{
    id: number;
    name: string;
    description: string;
    latLng: LatLng;
    location: Location;

    constructor(obj?: {
                        id: number, 
                        name: string,
                        description: string,
                        latLng: LatLng,
                        location: Location, 
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.name = obj.name;
            this.description = obj.description;
            this.latLng = obj.latLng;
            this.location = obj.location;
        }
        else{
            this.id = 0;
        }
    }
}