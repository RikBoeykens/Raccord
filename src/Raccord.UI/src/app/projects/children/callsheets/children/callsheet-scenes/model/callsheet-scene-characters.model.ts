import { BaseModel } from '../../../../../../shared/model/base.model';
import { Scene } from '../../../../scenes/model/scene.model';
import { LinkedCharacter } from '../../../../characters/model/linked-character.model';

export class CallsheetSceneCharacters extends BaseModel{
    id: number;
    pageLength: number;
    scene: Scene;
    availableCharacters: LinkedCharacter[];
    characters: LinkedCharacter[];

    constructor(obj?: {
                        id: number, 
                        pageLength: number,
                        scene: Scene, 
                        availableCharacters: LinkedCharacter[],
                        characters: LinkedCharacter[],
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.pageLength = obj.pageLength;
            this.scene = obj.scene;
            this.availableCharacters = obj.availableCharacters;
            this.characters = obj.characters;
        }
        else{
            this.id = 0;
        }
    }
}