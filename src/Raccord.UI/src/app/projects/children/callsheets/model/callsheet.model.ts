import { BaseModel } from '../../../../shared/model/base.model';
import { ShootingDay } from "../../shooting-days";

export class Callsheet extends BaseModel{
    id: number;
    start: Date;
    end: Date;
    crewCall: Date;
    shootingDay: ShootingDay;
    projectId: number;

    constructor(obj?: {
                        id: number,
                        start: Date,
                        end: Date,
                        crewCall: Date,
                        shootingDay: ShootingDay,
                        projectId: number,
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.start = obj.start;
            this.end = obj.end;
            this.crewCall = obj.crewCall;
            this.shootingDay = obj.shootingDay;
            this.projectId = obj.projectId;
        }
        else{
            this.id = 0;
        }
    }
}