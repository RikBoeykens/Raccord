import { Location } from "./location.model";
import { LocationSetScriptLocation } from "../../";
import { Address } from '../../../../../shared';
import { LatLng } from '../../../../../shared';
import { ScheduleDaySceneCollection } from '../../../scheduling/schedule-days/model/schedule-day-scene-collection.model';

export class FullLocation extends Location{
    sets: LocationSetScriptLocation[];
    scheduleDays: ScheduleDaySceneCollection[];

    constructor(obj?: {
                        id: number, 
                        name: string,
                        description: string,
                        address: Address,
                        latLng: LatLng,
                        sets: LocationSetScriptLocation[],
                        scheduleDays: ScheduleDaySceneCollection[],
                        projectId: number
                    }){
        super(obj);
        if(obj){
            this.sets = obj.sets;
            this.scheduleDays = obj.scheduleDays;
        }
        else{
            this.id = 0;
        }
    }
}