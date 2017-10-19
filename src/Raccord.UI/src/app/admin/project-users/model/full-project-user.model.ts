import { BaseModel } from '../../../shared/model/base.model';
import { Project } from "../../../projects/index";
import { User } from "../../users/model/user.model";

export class FullProjectUser extends BaseModel{
    id: number;
    project: Project;
    user: User;

    constructor(obj?: {
        id: number, 
        project: Project,
        user: User
    }){
        super();
        if(obj){
            this.id = obj.id;
            this.project = obj.project;
            this.user = obj.user;
        }
    }
}