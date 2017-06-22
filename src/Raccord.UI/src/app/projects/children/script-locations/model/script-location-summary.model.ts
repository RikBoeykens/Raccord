import { ScriptLocation } from './script-location.model';
import { Image } from '../../images/model/image.model';

export class ScriptLocationSummary extends ScriptLocation{
    sceneCount: number;
    primaryImage: Image;

    constructor(obj?: {
                        id: number, 
                        name: string, 
                        description: string,
                        projectId: number,
                        sceneCount: number,
                        primaryImage: Image
                    }){
        super(obj);
        if(obj){
            this.sceneCount = obj.sceneCount;
            this.primaryImage = obj.primaryImage;
        }
    }
}