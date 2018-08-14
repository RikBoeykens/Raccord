import { BaseScheduleDay } from './base-schedule-day.model';

export class ScheduleDay extends BaseScheduleDay {
    public crewUnitID: number;

    constructor(obj?: {
                        id: number,
                        date: Date,
                        start?: Date,
                        end?: Date,
                        crewUnitID: number
                    }) {
        super(obj);
        if (obj) {
            this.crewUnitID = obj.crewUnitID;
        }
    }
}
