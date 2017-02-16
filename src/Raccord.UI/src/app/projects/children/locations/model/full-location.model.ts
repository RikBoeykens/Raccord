import { Location } from './location.model';
import { SceneSummary } from '../../scenes/model/scene-summary.model';

export class FullLocation extends Location{
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