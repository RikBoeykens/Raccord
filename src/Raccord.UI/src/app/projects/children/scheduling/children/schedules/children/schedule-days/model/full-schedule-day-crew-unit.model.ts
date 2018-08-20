import {
    BaseScheduleDay,
    ScheduleSceneScene,
    ScheduleDayNote,
    ShootingDay
} from '../../../../../../..';
import { CrewUnit } from '../../../../../../../../shared/children/crew';

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
