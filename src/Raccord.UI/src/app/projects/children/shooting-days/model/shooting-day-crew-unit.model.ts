import { BaseShootingDay } from './base-shooting-day.model';
import { CrewUnit } from '../../crew/crew-units/model/crew-unit.model';

export class ShootingDayCrewUnit extends BaseShootingDay {
    public crewUnit: CrewUnit;

    constructor(obj?: {
                        id: number,
                        number: string,
                        date: Date,
                        start: Date,
                        turn: Date,
                        end: Date,
                        overTime: string,
                        completed: boolean,
                        scheduleDayID?: number,
                        callsheetID?: number,
                        crewUnit: CrewUnit
                    }) {
        super(obj);
        if (obj) {
            this.crewUnit = obj.crewUnit;
        }
    }
}
