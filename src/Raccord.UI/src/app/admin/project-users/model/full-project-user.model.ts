import { BaseModel } from '../../../shared/model/base.model';
import { Project } from "../../../projects/index";
import { User } from "../../users/model/user.model";
import { CrewMember } from '../../../projects/children/crew/crew-members/model/crew-member.model';

export class FullProjectUser extends BaseModel{
    id: number;
    project: Project;
    user: User;
    crewMembers: CrewMember[];

    constructor(obj?: {
        id: number, 
        project: Project,
        user: User,
        crewMembers: CrewMember[]
    }){
        super();
        if(obj){
            this.id = obj.id;
            this.project = obj.project;
            this.user = obj.user;
            this.crewMembers = obj.crewMembers;
        }
    }
}