import { Image } from './image.model';
import { LinkedScene } from '../../scenes/model/linked-scene.model';
import { LinkedLocation } from '../../locations/model/linked-location.model';

export class FullImage extends Image{
    isPrimary: boolean;
    scenes: LinkedScene[];
    locations: LinkedLocation[];

    constructor(obj?: {
                        id: number, 
                        title: string, 
                        description: string,
                        fileName: string,
                        projectId: number,
                        isPrimary: boolean,
                        scenes: LinkedScene[],
                        locations: LinkedLocation[]
                    }){
        super(obj);
        if(obj){
            this.isPrimary = obj.isPrimary;
            this.scenes = obj.scenes;
            this.locations = obj.locations;
        }
    }
}