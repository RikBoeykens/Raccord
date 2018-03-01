import { ScheduleDay } from './schedule-day.model';
import { ScheduleSceneScene } from '../../schedule-scenes/model/schedule-scene-scene.model';
import { ScheduleDayNote } from '../../schedule-day-notes/model/schedule-day-note.model';
import { ShootingDay } from '../../../shooting-days';

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
