import { BaseModel } from '../../../../shared/model/base.model';

export class Character extends BaseModel{
    id: number;
    number: number;
    name: string;
    description: string;
    projectId: number;

    constructor(obj?: {
                        id: number,
                        number: number,
                        name: string,
                        description: string,
                        projectId: number,
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.number = obj.number;
            this.name = obj.name;
            this.description = obj.description;
            this.projectId = obj.projectId;
        }
        else{
            this.id = 0;
        }
    }
}