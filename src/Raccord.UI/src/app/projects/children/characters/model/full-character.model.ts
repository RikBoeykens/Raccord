import { Character } from './character.model';
import { LinkedScene } from '../../scenes/model/linked-scene.model';
import { LinkedImage } from '../../images/model/linked-image.model';
import { ScheduleDaySceneCollection } from
    '../../scheduling/schedule-days/model/schedule-day-scene-collection.model';
import { UserProfileSummary } from '../../../../profile/model/user-profile-summary.model';

export class FullCharacter extends Character {
    public scenes: LinkedScene[];
    public images: LinkedImage[];
    public scheduleDays: ScheduleDaySceneCollection[];
    public user: UserProfileSummary;

    constructor(obj?: {
                        id: number,
                        number: number,
                        name: string,
                        description: string,
                        projectId: number,
                        scenes: LinkedScene[],
                        images: LinkedImage[],
                        scheduleDays: ScheduleDaySceneCollection[],
                        user: UserProfileSummary
                    }) {
        super(obj);
        if (obj) {
            this.scenes = obj.scenes;
            this.images = obj.images;
            this.scheduleDays = obj.scheduleDays;
            this.user = obj.user;
        }
    }
}
