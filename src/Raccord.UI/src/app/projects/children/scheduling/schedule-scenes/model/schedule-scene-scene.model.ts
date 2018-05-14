import { BaseModel } from '../../../../../shared/model/base.model';
import { Scene } from '../../../scenes/model/scene.model';
import { LinkedCharacter } from '../../../characters/model/linked-character.model';
import { LocationSetSummary } from '../../../locations';

export class ScheduleSceneScene extends BaseModel {
    public id: number;
    public pageLength: number;
    public scene: Scene;
    public characters: LinkedCharacter[];
    public locationSet: LocationSetSummary;

    constructor(obj?: {
                        id: number,
                        pageLength: number,
                        scene: Scene,
                        characters: LinkedCharacter[],
                        locationSet: LocationSetSummary,
                    }) {
        super();
        if (obj) {
            this.id = obj.id;
            this.pageLength = obj.pageLength;
            this.scene = obj.scene;
            this.characters = obj.characters;
            this.locationSet = obj.locationSet;
        } else {
            this.id = 0;
        }
    }
}
