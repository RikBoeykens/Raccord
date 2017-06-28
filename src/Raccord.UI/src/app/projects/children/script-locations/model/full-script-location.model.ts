import { ScriptLocation } from './script-location.model';
import { SceneSummary } from '../../scenes/model/scene-summary.model';
import { LinkedImage } from '../../images/model/linked-image.model';

export class FullScriptLocation extends ScriptLocation{
    scenes: SceneSummary[];
    images: LinkedImage[];

    constructor(obj?: {
                        id: number, 
                        name: string, 
                        description: string,
                        projectId: number,
                        scenes: SceneSummary[],
                        images: LinkedImage[]
                    }){
        super(obj);
        if(obj){
            this.scenes = obj.scenes;
            this.images = obj.images;
        }
    }
}