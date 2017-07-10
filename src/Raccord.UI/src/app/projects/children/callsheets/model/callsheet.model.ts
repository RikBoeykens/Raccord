import { BaseModel } from '../../../../shared/model/base.model';
import { ShootingDay } from "../../shooting-days";

export class Callsheet extends BaseModel{
    id: number;
    shootingDay: ShootingDay;
    projectId: number;

    constructor(obj?: {
                        id: number,
                        shootingDay: ShootingDay,
                        projectId: number,
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.shootingDay = obj.shootingDay;
            this.projectId = obj.projectId;
        }
        else{
            this.id = 0;
        }
    }
}