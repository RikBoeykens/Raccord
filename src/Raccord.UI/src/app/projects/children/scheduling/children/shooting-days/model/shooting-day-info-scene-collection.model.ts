import { CrewUnit } from '../../../../../../shared/children/crew';
import { ShootingDayTypeEnum } from '../../../../../../shared';
import { ShootingDayInfo } from './shooting-day-info.model';
import { ShootingDaySceneSummary } from '../../../../..';

export class ShootingDayInfoSceneCollection extends ShootingDayInfo {
    public scenes: ShootingDaySceneSummary[];

    constructor(obj?: {
                        id: number,
                        number: string,
                        date: Date,
                        type: ShootingDayTypeEnum,
                        crewUnit: CrewUnit,
                        scenes: ShootingDaySceneSummary[]
                    }) {
        super(obj);
        if (obj) {
            this.scenes = obj.scenes;
        }
    }
}
