import { BaseModel } from '../../../shared/model/base.model';

export class CrewUser extends BaseModel{
    id: number;
    projectID: number;
    userID: string;

    constructor(obj?: {
        id: number, 
        projectID: number,
        userID: string
    }){
        super();
        if(obj){
            this.id = obj.id;
            this.projectID = obj.projectID;
            this.userID = obj.userID;
        }
    }
}