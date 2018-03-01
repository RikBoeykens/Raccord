import { BaseModel } from '../../../../../shared/model/base.model';

export class ScheduleDay extends BaseModel {
    public id: number;
    public date: Date;
    public start?: Date;
    public end?: Date;
    public crewUnitID: number;

    constructor(obj?: {
                        id: number,
                        date: Date,
                        start?: Date,
                        end?: Date,
                        crewUnitID: number
                    }) {
        super();
        if (obj) {
            this.id = obj.id;
            this.date = obj.date;
            this.start = obj.start;
            this.end = obj.end;
            this.crewUnitID = obj.crewUnitID;
        } else {
            this.id = 0;
        }
    }
}
