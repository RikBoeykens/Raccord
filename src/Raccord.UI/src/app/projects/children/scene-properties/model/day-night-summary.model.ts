import { DayNight } from './day-night.model';

export class DayNightSummary extends DayNight{
    sceneCount: number;

    constructor(obj?: {
                        id: number, 
                        name: string, 
                        description: string,
                        projectId: number,
                        sceneCount: number
                    }){
        super(obj);
        if(obj){
            this.sceneCount = obj.sceneCount;
        }
    }
}