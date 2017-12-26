import { Character } from '../../characters/model/character.model';
import { BaseSceneComponent } from './base-scene-component.model';

export class SceneDialogue extends BaseSceneComponent {
    character: Character;

    constructor(obj?: {
                      text: string,
                      order: number,
                      type: string,
                      character: Character
                    }){
        super(obj);
        if(obj){
            this.character = obj.character;
        }
    }
}