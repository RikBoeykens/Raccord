import { CharacterSummary } from '../../../../../../shared/children/characters';
import { CastMember } from '../../../../../../shared/children/cast/model/cast-member.model';
import { SceneSummary } from '../../../../../../shared/children/scenes';
import { ShootingDayInfoSceneCollection } from '../../../../..';

export class FullCastMember extends CastMember {
    public userID: string;
    public userInvitationID: string;
    public hasImage: boolean;
    public characters: CharacterSummary[];
    public scenes: SceneSummary[];
    public shootingDays: ShootingDayInfoSceneCollection[];

    constructor(obj?: {
                        id: number,
                        firstName: string,
                        lastName: string,
                        telephone: string,
                        email: string,
                        projectID: number,
                        userID: string,
                        userInvitationID: string,
                        hasImage: boolean,
                        characters: CharacterSummary[],
                        scenes: SceneSummary[],
                        shootingDays: ShootingDayInfoSceneCollection[]
                    }) {
        super(obj);
        if (obj) {
            this.userID = obj.userID;
            this.userInvitationID = obj.userInvitationID;
            this.hasImage = obj.hasImage;
            this.characters = obj.characters;
            this.scenes = obj.scenes;
            this.shootingDays = obj.shootingDays;
        }
    }
}
