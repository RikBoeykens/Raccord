import { Callsheet } from './callsheet.model';
import { ShootingDay } from "../../shooting-days";

export class FullCallsheet extends Callsheet{

    constructor(obj?: {
                        id: number,
                        shootingDay: ShootingDay,
                        projectId: number,
                    }){
        super(obj);
    }
}