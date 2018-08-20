import { ScheduleDay } from './schedule-day.model';
import {
    ShootingDay,
    ScheduleSceneScene,
    ScheduleDayNote
} from '../../../../../../..';

export class FullScheduleDay extends ScheduleDay {
    public scenes: ScheduleSceneScene[];
    public notes: ScheduleDayNote[];
    public shootingDay: ShootingDay;

    constructor(obj?: {
                        id: number,
                        date: Date,
                        start?: Date,
                        end?: Date,
                        crewUnitID: number,
                        scenes: ScheduleSceneScene[],
                        notes: ScheduleDayNote[],
                        shootingDay: ShootingDay
                    }) {
        super(obj);
        if (obj) {
            this.scenes = obj.scenes;
            this.notes = obj.notes;
            this.shootingDay = obj.shootingDay;
        }
    }
}
