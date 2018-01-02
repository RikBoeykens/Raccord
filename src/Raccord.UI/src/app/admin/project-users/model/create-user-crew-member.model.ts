import { BaseModel } from '../../../shared/model/base.model';

export class CreateUserCrewMember extends BaseModel{
    projectUserId: number;
    jobTitle: string;
    departmentId: number;

    constructor(obj?: {
        projectUserId: number, 
        jobTitle: string,
        departmentId: number
    }){
        super();
        if(obj){
            this.projectUserId = obj.projectUserId;
            this.jobTitle = obj.jobTitle;
            this.departmentId = obj.departmentId;
        }
    }
}