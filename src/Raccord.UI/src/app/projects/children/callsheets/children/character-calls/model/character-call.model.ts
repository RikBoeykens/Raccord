import { BaseModel } from '../../../../../../shared/model/base.model';

export class CharacterCall extends BaseModel{
    id: number;
    callTime: Date;

    constructor(obj?: {
                        id: number, 
                        callTime: Date, 
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.callTime = obj.callTime;
        }
        else{
            this.id = 0;
        }
    }
}