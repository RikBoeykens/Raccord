import { BaseModel } from '../../../shared/model/base.model';
import { User } from "../../users/model/user.model";

export class CrewUserUser extends BaseModel{
    id: number;
    user: User;

    constructor(obj?: {
        id: number, 
        user: User
    }){
        super();
        if(obj){
            this.id = obj.id;
            this.user = obj.user;
        }
    }
}