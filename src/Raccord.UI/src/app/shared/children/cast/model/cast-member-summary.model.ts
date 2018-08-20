import { CastMember } from './cast-member.model';

export class CastMemberSummary extends CastMember {
    public userID: string;
    public userInvitationID: string;
    public hasImage: boolean;

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
        hasImage: boolean
    }) {
        super(obj);
        if (obj) {
            this.userID = obj.userID;
            this.userInvitationID = obj.userInvitationID;
            this.hasImage = obj.hasImage;
        }
    }
}
