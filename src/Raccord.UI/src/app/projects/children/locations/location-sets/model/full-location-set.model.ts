import { LocationSetSummary } from "./location-set-summary.model";
import { Address } from '../../../../../shared';
import { LatLng } from '../../../../../shared';
import { Location } from "../../";
import { ScriptLocation } from "../../../../children/script-locations/model/script-location.model";

export class FullLocationSet extends LocationSetSummary{
    linkID: number;

    constructor(obj?: {
                        id: number, 
                        name: string,
                        description: string,
                        latLng: LatLng,
                        location: Location, 
                        scriptLocation: ScriptLocation
                        linkID: number
                    }){
        super(obj);
        if(obj){
            this.linkID = obj.linkID;
        }
    }
}