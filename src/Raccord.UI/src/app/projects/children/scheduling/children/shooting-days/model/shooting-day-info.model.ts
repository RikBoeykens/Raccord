import { CrewUnit } from '../../../../../../shared/children/crew';
import { ShootingDayTypeEnum } from '../../../../../../shared';

export class ShootingDayInfo {
    public id: number;
    public number: string;
    public date: Date;
    public type: ShootingDayTypeEnum;
    public crewUnit: CrewUnit;

    constructor(obj?: {
                        id: number,
                        number: string,
                        date: Date,
                        type: ShootingDayTypeEnum,
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
