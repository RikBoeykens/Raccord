import { BaseModel } from '../../../../../shared/model/base.model';
import { ScheduleSceneSummary } from "../model/schedule-scene-summary.model";
import { ScheduleDay } from '../../schedule-days/model/schedule-day.model';
import { Scene } from '../../../scenes/model/scene.model';

export class LinkedScheduleScene extends ScheduleSceneSummary{
    linkID: number;

    constructor(obj?: {
                        id: number, 
                        pageLength: number,
                        scene: Scene, 
                        scheduleDay: ScheduleDay,
                        linkID: number
                    }){
        super(obj);
        if(obj){
            this.linkID = obj.linkID;
        }
    }
}