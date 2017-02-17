import { IntExt } from './int-ext.model';
import { SceneSummary } from '../../scenes/model/scene-summary.model';

export class IntExtSummary extends IntExt{
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