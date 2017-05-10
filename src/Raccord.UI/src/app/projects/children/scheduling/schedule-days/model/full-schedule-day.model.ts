import { ScheduleDay } from './schedule-day.model';
import { ScheduleSceneScene } from '../../schedule-scenes/model/schedule-scene-scene.model';
import { ScheduleDayNote } from '../../schedule-day-notes/model/schedule-day-note.model';

export class FullScheduleDay extends ScheduleDay{
    scenes: ScheduleSceneScene[];
    notes: ScheduleDayNote[];

    constructor(obj?: {
                        id: number, 
                        date: Date, 
                        start?: Date, 
                        end?: Date, 
                        projectId: number,
                        scenes: ScheduleSceneScene[],
                        notes: ScheduleDayNote[]
                    }){
        super(obj);
        if(obj){
            this.scenes = obj.scenes;
            this.notes = obj.notes;
        }
        else{
            this.id = 0;
        }
    }
}