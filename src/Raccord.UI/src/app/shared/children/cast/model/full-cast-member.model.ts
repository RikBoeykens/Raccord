import { CastMember } from './cast-member.model';
import { CharacterSummary } from '../../characters';
import { SceneSummary } from '../../scenes';

export class FullCastMember extends CastMember {
    public userID: string;
    public userInvitationID: string;
    public hasImage: boolean;
    public characters: CharacterSummary[];
    public scenes: SceneSummary[];

    constructor(
        obj?: {
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
        scenes: SceneSummary[]
    }) {
        super(obj);
        if (obj) {
            this.userID = obj.userID;
            this.userInvitationID = obj.userInvitationID;
            this.hasImage = obj.hasImage;
            this.characters = obj.characters;
            this.scenes = obj.scenes;
        }
    }
}
