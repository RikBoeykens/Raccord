import { BaseModel } from '../../../shared/model/base.model';

export class CreateCrewUnitMemberCrewMember extends BaseModel {
    public crewUnitMemberID: number;
    public jobTitle: string;
    public departmentID: number;

    constructor(obj?: {
        crewUnitMemberID: number,
        jobTitle: string,
        departmentID: number
    }) {
        super();
        if (obj) {
            this.crewUnitMemberID = obj.crewUnitMemberID;
            this.jobTitle = obj.jobTitle;
            this.departmentID = obj.departmentID;
        }
    }
}
