import { CharacterCall } from './character-call.model';
import { CallType } from '../../../../..';

export class CharacterCallCallType extends CharacterCall {
    public callType: CallType;

    constructor(
        obj?: any
    ) {
        super(obj);
        if (obj) {
            this.callType = obj.callType;
        } else {
            this.id = 0;
        }
    }
}
