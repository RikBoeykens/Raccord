import { LocationSetSummary } from "./location-set-summary.model";
import { Address } from '../../../../../shared';
import { LatLng } from '../../../../../shared';
import { Location } from "../../";
import { ScriptLocation } from "../../../../children/script-locations/model/script-location.model";
import { ScheduleDaySceneCollection } from '../../../scheduling/schedule-days/model/schedule-day-scene-collection.model';

export class FullLocationSet extends LocationSetSummary{
    scheduleDays: ScheduleDaySceneCollection[];

    constructor(obj?: {
                        id: number, 
                        name: string,
                        description: string,
                        latLng: LatLng,
                        location: Location, 
                        scriptLocation: ScriptLocation,
                        scheduleDays: ScheduleDaySceneCollection[]
                    }){
        super(obj);
        if(obj){
            this.scheduleDays = obj.scheduleDays;
        }
    }
}