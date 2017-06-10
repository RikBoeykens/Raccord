import { BaseModel } from '../../../../../shared/model/base.model';
import { ScheduleDay } from '../../schedule-days/model/schedule-day.model';
import { Scene } from '../../../scenes/model/scene.model';

export class FullScheduleScene extends BaseModel{
    id: number;
    pageLength: number;
    sceneScheduledPageLength: number;
    scene: Scene;
    scheduleDay: ScheduleDay;

    constructor(obj?: {
                        id: number, 
                        pageLength: number,
                        sceneScheduledPageLength: number, 
                        scene: Scene, 
                        scheduleDay: ScheduleDay
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.pageLength = obj.pageLength;
            this.sceneScheduledPageLength = obj.sceneScheduledPageLength;
            this.scene = obj.scene;
            this.scheduleDay = obj.scheduleDay;
        }
        else{
            this.id = 0;
        }
    }
}