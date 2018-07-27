import { BaseCallsheet } from './base-callsheet.model';
import { CrewUnit } from '../../../../shared/children/crew';
import { ShootingDay } from '../../..';

export class CallsheetCrewUnit extends BaseCallsheet {
    public crewUnit: CrewUnit;

    constructor(obj?: {
                        id: number,
                        start: Date,
                        end: Date,
                        crewCall: Date,
                        shootingDay: ShootingDay,
                        crewUnitID: number,
                        crewUnit: CrewUnit
                    }) {
        super(obj);
        if (obj) {
            this.crewUnit = obj.crewUnit;
        }
    }
}
