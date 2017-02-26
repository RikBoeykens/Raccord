import { BaseModel } from '../../../../shared/model/base.model';

export class Image extends BaseModel{
    id: number;
    title: string;
    description: string;
    fileName: string;
    projectId: number;

    constructor(obj?: {
                        id: number, 
                        title: string, 
                        description: string,
                        fileName: string,
                        projectId: number
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.title = obj.title;
            this.description = obj.description;
            this.fileName = obj.fileName;
            this.projectId = obj.projectId;
        }
        else{
            this.id = 0;
        }
    }
}