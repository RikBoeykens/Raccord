import { BaseScheduleDay } from './base-schedule-day.model';
import { ScheduleSceneScene } from '../../schedule-scenes/model/schedule-scene-scene.model';
import { ScheduleDayNote } from '../../schedule-day-notes/model/schedule-day-note.model';
import { ShootingDay } from '../../../shooting-days';
import { CrewUnit } from '../../../crew/crew-units/model/crew-unit.model';

export class FullScheduleDayCrewUnit extends BaseScheduleDay {
    public scenes: ScheduleSceneScene[];
    public notes: ScheduleDayNote[];
    public shootingDay: ShootingDay;
    public crewUnit: CrewUnit;

    constructor(obj?: {
                        id: number,
                        date: Date,
                        start?: Date,
                        end?: Date,
                        scenes: ScheduleSceneScene[],
                        notes: ScheduleDayNote[],
                        shootingDay: ShootingDay,
                        crewUnit: CrewUnit
                    }) {
        super(obj);
        if (obj) {
            this.scenes = obj.scenes;
            this.notes = obj.notes;
            this.shootingDay = obj.shootingDay;
            this.crewUnit = obj.crewUnit;
        }
    }
}
