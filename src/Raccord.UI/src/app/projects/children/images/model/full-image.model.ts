import { Image } from './image.model';
import { Scene } from '../../scenes/model/scene.model';
import { Location } from '../../locations/model/location.model';

export class FullImage extends Image{
    isPrimary: boolean;
    scenes: Scene[];
    locations: Location[];

    constructor(obj?: {
                        id: number, 
                        title: string, 
                        description: string,
                        fileName: string,
                        projectId: number,
                        isPrimary: boolean,
                        scenes: Scene[],
                        locations: Location[]
                    }){
        super(obj);
        if(obj){
            this.isPrimary = obj.isPrimary;
            this.scenes = obj.scenes;
            this.locations = obj.locations;
        }
    }
}