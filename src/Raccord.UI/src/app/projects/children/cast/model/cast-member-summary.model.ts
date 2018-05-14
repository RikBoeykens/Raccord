import { CastMember } from './cast-member.model';

export class CastMemberSummary extends CastMember {
    public userID: string;
    public hasImage: boolean;

    constructor(obj?: {
                        id: number,
                        firstName: string,
                        lastName: string,
                        telephone: string,
                        email: string,
                        projectID: number,
                        userID: string,
                        hasImage: boolean
                    }) {
        super(obj);
        if (obj) {
            this.userID = obj.userID;
            this.hasImage = obj.hasImage;
        }
    }
}
