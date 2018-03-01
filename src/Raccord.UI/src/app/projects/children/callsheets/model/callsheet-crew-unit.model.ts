import { BaseCallsheet } from './base-callsheet.model';
import { ShootingDay } from '../../shooting-days';
import { CrewUnit } from '../../crew/crew-units/model/crew-unit.model';

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
