import { CharacterSummary } from './character-summary.model';
import { Image } from '../../images/model/image.model';

export class LinkedCharacter extends CharacterSummary{
    linkID: number;

    constructor(obj?: {
                        id: number,
                        number: number,
                        name: string,
                        description: string,
                        projectId: number,
                        sceneCount: number,
                        primaryImage: Image,
                        linkID: number
                    }){
        super(obj);
        if(obj){
            this.linkID = obj.linkID;
        }
    }
}