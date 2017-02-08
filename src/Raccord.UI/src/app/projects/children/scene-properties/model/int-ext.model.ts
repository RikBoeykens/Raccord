import { IntExtSummary } from './int-ext-summary.model';
import { SceneSummary } from '../../scenes/model/scene-summary.model';

export class IntExt extends IntExtSummary{
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