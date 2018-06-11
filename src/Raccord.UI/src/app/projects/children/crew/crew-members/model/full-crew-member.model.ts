import { CrewDepartment } from '../../departments/model/crew-department.model';
import { CrewMember } from './crew-member.model';
import { CrewUnit } from '../../crew-units/model/crew-unit.model';

export class FullCrewMember extends CrewMember {
    public userID: string;
    public userInvitationID: string;
    public hasImage: boolean;
    public crewUnit: CrewUnit;

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
                        hasImage: boolean,
                        crewUnit: CrewUnit
                    }) {
        super(obj);
        this.userID = obj.userID;
        this.userInvitationID = obj.userInvitationID;
        this.hasImage = obj.hasImage;
        this.crewUnit = obj.crewUnit;
    }
}