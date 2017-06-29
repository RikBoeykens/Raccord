import { Location } from "./location.model";
import { LocationSetScriptLocation } from "../../";
import { Address } from '../../../../../shared';
import { LatLng } from '../../../../../shared';

export class FullLocation extends Location{
    sets: LocationSetScriptLocation[];

    constructor(obj?: {
                        id: number, 
                        name: string,
                        description: string,
                        address: Address,
                        latLng: LatLng,
                        sets: LocationSetScriptLocation[];
                        projectId: number
                    }){
        super(obj);
        if(obj){
            this.sets = obj.sets;
        }
        else{
            this.id = 0;
        }
    }
}