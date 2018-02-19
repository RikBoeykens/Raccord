import { Character } from './character.model';
import { LinkedScene } from '../../scenes/model/linked-scene.model';
import { LinkedImage } from '../../images/model/linked-image.model';
import { ScheduleDaySceneCollection } from
    '../../scheduling/schedule-days/model/schedule-day-scene-collection.model';
import { CastMemberSummary } from '../../cast/model/cast-member-summary.model';

export class FullCharacter extends Character {
    public scenes: LinkedScene[];
    public images: LinkedImage[];
    public scheduleDays: ScheduleDaySceneCollection[];
    public castMember: CastMemberSummary;

    constructor(obj?: {
                        id: number,
                        number: number,
                        name: string,
                        description: string,
                        projectId: number,
                        scenes: LinkedScene[],
                        images: LinkedImage[],
                        scheduleDays: ScheduleDaySceneCollection[],
                        castMember: CastMemberSummary
                    }) {
        super(obj);
        if (obj) {
            this.scenes = obj.scenes;
            this.images = obj.images;
            this.scheduleDays = obj.scheduleDays;
            this.castMember = obj.castMember;
        }
    }
}
