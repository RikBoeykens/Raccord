import { ScriptLocation } from './script-location.model';
import { SceneSummary } from '../../scenes/model/scene-summary.model';
import { LinkedImage } from '../../images/model/linked-image.model';
import { LocationSetLocation } from '../../locations';

export class FullScriptLocation extends ScriptLocation{
    scenes: SceneSummary[];
    images: LinkedImage[];
    sets: LocationSetLocation[];

    constructor(obj?: {
                        id: number, 
                        name: string, 
                        description: string,
                        projectId: number,
                        scenes: SceneSummary[],
                        images: LinkedImage[],
                        sets: LocationSetLocation[]
                    }){
        super(obj);
        if(obj){
            this.scenes = obj.scenes;
            this.images = obj.images;
            this.sets = obj.sets;
        }
    }
}