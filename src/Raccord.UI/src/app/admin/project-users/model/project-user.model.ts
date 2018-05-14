import { BaseModel } from '../../../shared/model/base.model';

export class ProjectUser extends BaseModel{
    id: number;
    projectID: number;
    userID: string;
    roleID?: number;

    constructor(obj?: {
        id: number, 
        projectID: number,
        userID: string,
        roleID?: number
    }){
        super();
        if(obj){
            this.id = obj.id;
            this.projectID = obj.projectID;
            this.userID = obj.userID;
            this.roleID = obj.roleID;
        }
    }
}