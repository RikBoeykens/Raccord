import { BaseModel } from '../../../../../shared/model/base.model';
import { BreakdownType } from '../../breakdown-types/model/breakdown-type.model';

export class BreakdownItem extends BaseModel{
    id: number;
    name: string;
    description: string;
    type: BreakdownType;

    constructor(obj?: {
                        id: number, 
                        name: string, 
                        description: string,
                        type: BreakdownType
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.name = obj.name;
            this.description = obj.description;
            this.type = obj.type;
        }
        else{
            this.id = 0;
        }
    }
}