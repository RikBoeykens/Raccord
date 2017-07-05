import { ScheduleDay } from './schedule-day.model';
import { ScheduleSceneScene } from '../../schedule-scenes/model/schedule-scene-scene.model';
import { ShootingDay } from "../../../shooting-days";

export class ScheduleDaySceneCollection extends ScheduleDay{
    scenes: ScheduleSceneScene[];
    shootingDay: ShootingDay;

    constructor(obj?: {
                        id: number, 
                        date: Date, 
                        start?: Date, 
                        end?: Date, 
                        projectId: number,
                        scenes: ScheduleSceneScene[],
                        shootingDay: ShootingDay
                    }){
        super(obj);
        if(obj){
            this.scenes = obj.scenes;
            this.shootingDay = obj.shootingDay;
        }
        else{
            this.id = 0;
        }
    }
}