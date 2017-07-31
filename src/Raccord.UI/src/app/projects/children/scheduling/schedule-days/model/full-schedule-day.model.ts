import { ScheduleDay } from './schedule-day.model';
import { ScheduleSceneScene } from '../../schedule-scenes/model/schedule-scene-scene.model';
import { ScheduleDayNote } from '../../schedule-day-notes/model/schedule-day-note.model';
import { ShootingDay } from "../../../shooting-days";

export class FullScheduleDay extends ScheduleDay{
    scenes: ScheduleSceneScene[];
    notes: ScheduleDayNote[];
    shootingDay: ShootingDay;

    constructor(obj?: {
                        id: number, 
                        date: Date, 
                        start?: Date, 
                        end?: Date, 
                        projectId: number,
                        scenes: ScheduleSceneScene[],
                        notes: ScheduleDayNote[],
                        shootingDay: ShootingDay
                    }){
        super(obj);
        if(obj){
            this.scenes = obj.scenes;
            this.notes = obj.notes;
            this.shootingDay = obj.shootingDay;
        }
        else{
            this.id = 0;
        }
    }
}