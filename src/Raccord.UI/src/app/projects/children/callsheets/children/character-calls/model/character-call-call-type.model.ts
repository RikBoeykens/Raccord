import { CallType } from "../../../";
import { CharacterCall } from "../../../"

export class CharacterCallCallType extends CharacterCall{
    callType: CallType;

    constructor(obj?: {
                        id: number, 
                        callTime: Date, 
                        callType: CallType
                    }){
        super(obj);
        if(obj){
            this.callType = obj.callType;
        }
        else{
            this.id = 0;
        }
    }
}