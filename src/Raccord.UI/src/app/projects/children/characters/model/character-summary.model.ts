import { Character } from './character.model';
import { Image } from '../../images/model/image.model';

export class CharacterSummary extends Character{
    sceneCount: number;
    primaryImage: Image;

    constructor(obj?: {
                        id: number,
                        number: number,
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