import { BaseModel } from '../../../shared/model/base.model';
import { ProjectRoleEnum } from '../enums/project-role.enum';

export class ProjectRole extends BaseModel{
    id: number;
    role: ProjectRoleEnum;
    name: string;
    description: string;

    constructor(obj?: {
        id: number, 
        role: ProjectRoleEnum,
        name: string,
        description: string
    }){
        super();
        if(obj){
            this.id = obj.id;
            this.role = obj.role;
            this.name = obj.name;
            this.description = obj.description;
        }
    }
}