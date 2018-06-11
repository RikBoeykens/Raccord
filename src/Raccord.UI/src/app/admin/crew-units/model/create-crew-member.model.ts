import { BaseModel } from '../../../shared/model/base.model';

export class CreateCrewMember extends BaseModel {
    public jobTitle: string;
    public departmentID: number;

    constructor(obj?: {
        jobTitle: string,
        departmentID: number
    }) {
        super();
        if (obj) {
            this.jobTitle = obj.jobTitle;
            this.departmentID = obj.departmentID;
        }
    }
}
