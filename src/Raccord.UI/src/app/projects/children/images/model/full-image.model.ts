import { Image } from './image.model';
import { Scene } from '../../scenes/model/scene.model';
import { Location } from '../../locations/model/location.model';

export class FullImage extends Image{
    scenes: Scene[];
    locations: Location[];

    constructor(obj?: {
                        id: number, 
                        title: string, 
                        description: string,
                        fileName: string,
                        projectId: number,
                        scenes: Scene[],
                        locations: Location[]
                    }){
        super(obj);
        if(obj){
            this.scenes = obj.scenes;
            this.locations = obj.locations;
        }
    }
}