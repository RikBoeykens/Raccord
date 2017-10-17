import { BaseModel } from '../../../shared/model/base.model';
import { Project } from "../../../projects/index";

export class ProjectUserProject extends BaseModel{
    id: number;
    project: Project;

    constructor(obj?: {
        id: number, 
        project: Project,
    }){
        super();
        if(obj){
            this.id = obj.id;
            this.project = obj.project;
        }
    }
}