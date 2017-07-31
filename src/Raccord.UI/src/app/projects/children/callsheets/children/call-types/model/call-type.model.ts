import { BaseModel } from '../../../../../../shared/model/base.model';

export class CallType extends BaseModel{
    id: number;
    shortName: string;
    name: string;
    description: string;
    projectId: number;

    constructor(obj?: {
                        id: number, 
                        shortName: string, 
                        name: string, 
                        description: string,
                        projectId: number
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.shortName = obj.shortName;
            this.name = obj.name;
            this.description = obj.description;
            this.projectId = obj.projectId;
        }
        else{
            this.id = 0;
        }
    }
}