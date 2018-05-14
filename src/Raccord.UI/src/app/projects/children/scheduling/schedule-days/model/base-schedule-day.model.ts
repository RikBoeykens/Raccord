import { BaseModel } from '../../../../../shared/model/base.model';

export class BaseScheduleDay extends BaseModel {
    public id: number;
    public date: Date;
    public start?: Date;
    public end?: Date;

    constructor(obj?: {
                        id: number,
                        date: Date,
                        start?: Date,
                        end?: Date
                    }) {
        super();
        if (obj) {
            this.id = obj.id;
            this.date = obj.date;
            this.start = obj.start;
            this.end = obj.end;
        } else {
            this.id = 0;
        }
    }
}
