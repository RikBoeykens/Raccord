import { BaseModel } from '../../../../../shared/model/base.model';

export class CallsheetBreakdownItem extends BaseModel{
    id: number;
    name: string;
    description: string;

    constructor(obj?: {
                        id: number, 
                        name: string, 
                        description: string,
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.name = obj.name;
            this.description = obj.description;
        }
        else{
            this.id = 0;
        }
    }
}