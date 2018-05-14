import { ShootingDayType } from '../../../../shared/enums/shooting-day-type.enum';
import { CrewUnit } from '../../crew/crew-units/model/crew-unit.model';

export class ShootingDayInfo {
    public id: number;
    public number: string;
    public date: Date;
    public type: ShootingDayType;
    public crewUnit: CrewUnit;

    constructor(obj?: {
                        id: number,
                        number: string,
                        date: Date,
                        type: ShootingDayType,
                        crewUnit: CrewUnit
                    }) {
        if (obj) {
            this.id = obj.id;
            this.number = obj.number;
            this.date = obj.date;
            this.type = obj.type;
            this.crewUnit = obj.crewUnit;
        } else {
            this.id = 0;
        }
    }
}
