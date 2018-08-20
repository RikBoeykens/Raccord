import { BaseModel } from '../../../../../../shared';

export class CharacterCall extends BaseModel {
    public id: number;
    public callTime: Date;

    constructor(
        obj?: {
        id: number,
        callTime: Date,
    }) {
        super();
        if (obj) {
            this.id = obj.id;
            this.callTime = obj.callTime;
        } else {
            this.id = 0;
        }
    }
}
