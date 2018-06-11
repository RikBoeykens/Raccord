import { CrewDepartment } from '../../departments/model/crew-department.model';
import { CrewMember } from './crew-member.model';

export class CrewMemberSummary extends CrewMember {
    public userID: string;
    public userInvitationID: string;
    public hasImage: boolean;

    constructor(obj?: {
                        id: number,
                        firstName: string,
                        lastName: string,
                        jobTitle: string,
                        email: string,
                        telephone: string,
                        department: CrewDepartment,
                        userID: string,
                        userInvitationID: string,
                        hasImage: boolean
                    }) {
        super(obj);
        this.userID = obj.userID;
        this.userInvitationID = obj.userInvitationID;
        this.hasImage = obj.hasImage;
    }
}