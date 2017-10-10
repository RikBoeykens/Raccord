import { ShootingDayType } from "../../../../shared/enums/shooting-day-type.enum";

export class ShootingDayInfo{
    id: number;
    number: string;
    date: Date;
    type: ShootingDayType;

    constructor(obj?: {
                        id: number,
                        number: string, 
                        date: Date,
                        type: ShootingDayType
                    }){
        if(obj){
            this.id = obj.id;
            this.number = obj.number;
            this.date = obj.date;
            this.type = obj.type;
        }
        else{
            this.id = 0;
        }
    }
}