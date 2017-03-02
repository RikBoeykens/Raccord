import { Location } from './location.model';
import { SceneSummary } from '../../scenes/model/scene-summary.model';
import { Image } from '../../images/model/image.model';

export class FullLocation extends Location{
    scenes: SceneSummary[];
    images: Image[];

    constructor(obj?: {
                        id: number, 
                        name: string, 
                        description: string,
                        projectId: number,
                        scenes: SceneSummary[],
                        images: Image[]
                    }){
        super(obj);
        if(obj){
            this.scenes = obj.scenes;
            this.images = obj.images;
        }
    }
}