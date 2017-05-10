import { BaseModel } from '../../../../../shared/model/base.model';
import { ScheduleDay } from '../../schedule-days/model/schedule-day.model';

export class ScheduleSceneDay extends BaseModel{
    id: number;
    pageLength: number;
    scheduleDay: ScheduleDay;

    constructor(obj?: {
                        id: number, 
                        pageLength: number, 
                        scheduleDay: ScheduleDay
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.pageLength = obj.pageLength;
            this.scheduleDay = obj.scheduleDay;
        }
        else{
            this.id = 0;
        }
    }
}