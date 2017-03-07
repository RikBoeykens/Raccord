import { Character } from './character.model';
import { LinkedScene } from '../../scenes/model/linked-scene.model';
import { LinkedImage } from '../../images/model/linked-image.model';

export class FullCharacter extends Character{
    scenes: LinkedScene[];
    images: LinkedImage[];

    constructor(obj?: {
                        id: number,
                        number: number,
                        name: string,
                        description: string,
                        projectId: number,
                        scenes: LinkedScene[],
                        images: LinkedImage[]
                    }){
        super(obj);
        if(obj){
            this.scenes = obj.scenes;
            this.images = obj.images;
        }
    }
}