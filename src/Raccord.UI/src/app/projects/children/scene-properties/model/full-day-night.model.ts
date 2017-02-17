import { DayNight } from './day-night.model';
import { SceneSummary } from '../../scenes/model/scene-summary.model';

export class FullDayNight extends DayNight{
    scenes: SceneSummary[];

    constructor(obj?: {
                        id: number, 
                        name: string, 
                        description: string,
                        projectId: number,
                        scenes: SceneSummary[]
                    }){
        super(obj);
        if(obj){
            this.scenes = obj.scenes;
        }
    }
}