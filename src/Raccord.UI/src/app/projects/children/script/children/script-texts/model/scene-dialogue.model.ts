import { BaseSceneComponent } from './base-scene-component.model';
import { Character } from '../../../../../../shared/children/characters';

export class SceneDialogue extends BaseSceneComponent {
    public character: Character;

    constructor(obj?: {
                      text: string,
                      order: number,
                      type: string,
                      character: Character
                    }) {
        super(obj);
        if (obj) {
            this.character = obj.character;
        }
    }
}
