import { BaseModel } from '../../../shared/model/base.model';
import { ProjectSummary } from '../../../projects/index';

export class ProjectUserProject extends BaseModel{
    id: number;
    project: ProjectSummary;

    constructor(obj?: {
        id: number, 
        project: ProjectSummary,
    }){
        super();
        if(obj){
            this.id = obj.id;
            this.project = obj.project;
        }
    }
}