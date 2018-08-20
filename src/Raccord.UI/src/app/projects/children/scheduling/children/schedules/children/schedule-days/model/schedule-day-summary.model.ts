import { ScheduleDay } from './schedule-day.model';
import { ShootingDay } from '../../../../../../..';

export class ScheduleDaySummary extends ScheduleDay {
    public sceneCount: number;
    public pageLength: number;
    public shootingDay: ShootingDay;

    constructor(obj?: {
                        id: number,
                        date: Date,
                        start?: Date,
                        end?: Date,
                        crewUnitID: number,
                        sceneCount: number,
                        pageLength: number,
                        shootingDay: ShootingDay
                    }) {
        super(obj);
        if (obj) {
            this.sceneCount = obj.sceneCount;
            this.pageLength = obj.pageLength;
            this.shootingDay = obj.shootingDay;
        } else {
            this.id = 0;
        }
    }
}
