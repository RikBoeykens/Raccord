import { BaseModel } from '../../../shared/model/base.model';
import { UserSummary } from "../../users/model/user-summary.model";

export class ProjectUserUser extends BaseModel{
    id: number;
    user: UserSummary;

    constructor(obj?: {
        id: number, 
        user: UserSummary
    }){
        super();
        if(obj){
            this.id = obj.id;
            this.user = obj.user;
        }
    }
}