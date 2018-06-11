import { BaseModel } from '../../../shared/model/base.model';

export class CreateCrewUnitInvitationMemberCrewMember extends BaseModel {
    public crewUnitInvitationMemberID: number;
    public jobTitle: string;
    public departmentID: number;

    constructor(obj?: {
        crewUnitInvitationMemberID: number,
        jobTitle: string,
        departmentID: number
    }) {
        super();
        if (obj) {
            this.crewUnitInvitationMemberID = obj.crewUnitInvitationMemberID;
            this.jobTitle = obj.jobTitle;
            this.departmentID = obj.departmentID;
        }
    }
}
