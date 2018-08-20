import { BaseCallsheet } from './base-callsheet.model';
import { ShootingDay } from '../../..';

export class Callsheet extends BaseCallsheet {
    public crewUnitID: number;

    constructor(obj?: {
                        id: number,
                        start: Date,
                        end: Date,
                        crewCall: Date,
                        shootingDay: ShootingDay,
                        crewUnitID: number,
                    }) {
        super(obj);
        if (obj) {
            this.crewUnitID = obj.crewUnitID;
        }
    }
}
