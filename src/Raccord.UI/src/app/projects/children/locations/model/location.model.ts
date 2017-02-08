import { LocationSummary } from './location-summary.model';
import { SceneSummary } from '../../scenes/model/scene-summary.model';

export class Location extends LocationSummary{
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