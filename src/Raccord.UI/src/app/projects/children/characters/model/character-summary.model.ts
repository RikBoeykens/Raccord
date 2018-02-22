import { Character } from './character.model';
import { Image } from '../../images/model/image.model';
import { UserProfile } from '../../../../profile/model/user-profile.model';

export class CharacterSummary extends Character {
    public sceneCount: number;
    public primaryImage: Image;

    constructor(obj?: {
                        id: number,
                        number: number,
                        name: string,
                        description: string,
                        projectId: number,
                        sceneCount: number,
                        primaryImage: Image,
                    }) {
        super(obj);
        if (obj) {
            this.sceneCount = obj.sceneCount;
            this.primaryImage = obj.primaryImage;
        }
    }
}
