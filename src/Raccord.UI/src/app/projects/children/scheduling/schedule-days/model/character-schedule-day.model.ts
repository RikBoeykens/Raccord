import { ScheduleDay } from './schedule-day.model';
import { ScheduleSceneScene } from '../../schedule-scenes/model/schedule-scene-scene.model';
import { LinkedScene } from '../../../../children/scenes/model/linked-scene.model';

export class CharacterScheduleDay extends ScheduleDay{
    scenes: LinkedScene[];

    constructor(obj?: {
                        id: number, 
                        date: Date, 
                        start?: Date, 
                        end?: Date, 
                        projectId: number,
                        scenes: LinkedScene[],
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