import { ScheduleDay } from './schedule-day.model';
import { ScheduleSceneScene } from '../../schedule-scenes/model/schedule-scene-scene.model';

export class ScheduleDaySceneCollection extends ScheduleDay{
    scenes: ScheduleSceneScene[];

    constructor(obj?: {
                        id: number, 
                        date: Date, 
                        start?: Date, 
                        end?: Date, 
                        projectId: number,
                        scenes: ScheduleSceneScene[],
                    }){
        super(obj);
        if(obj){
            this.scenes = obj.scenes;
        }
        else{
            this.id = 0;
        }
    }
}