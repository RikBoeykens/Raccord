import { BaseModel } from '../../../../../../shared/model/base.model';
import { CallType } from "../../../";

export class CharacterCallCallType extends BaseModel{
    id: number;
    callTime: Date;
    callType: CallType;

    constructor(obj?: {
                        id: number, 
                        callTime: Date, 
                        callType: CallType
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.callTime = obj.callTime;
            this.callType = obj.callType;
        }
        else{
            this.id = 0;
        }
    }
}