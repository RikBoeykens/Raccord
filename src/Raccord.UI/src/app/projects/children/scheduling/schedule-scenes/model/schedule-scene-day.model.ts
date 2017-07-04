import { BaseModel } from '../../../../../shared/model/base.model';
import { ScheduleDay } from '../../schedule-days/model/schedule-day.model';
import { LocationSetSummary } from "../../../locations";

export class ScheduleSceneDay extends BaseModel{
    id: number;
    pageLength: number;
    scheduleDay: ScheduleDay;
    locationSet: LocationSetSummary;

    constructor(obj?: {
                        id: number, 
                        pageLength: number, 
                        scheduleDay: ScheduleDay,
                        locationSet: LocationSetSummary,
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.pageLength = obj.pageLength;
            this.scheduleDay = obj.scheduleDay;
            this.locationSet = obj.locationSet;
        }
        else{
            this.id = 0;
        }
    }
}