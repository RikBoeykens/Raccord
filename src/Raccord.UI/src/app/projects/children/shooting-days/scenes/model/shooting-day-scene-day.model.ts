import { BaseShootingDayScene } from "./base-shooting-day-scene.model";
import { LocationSetSummary } from "../../../locations/index";
import { ShootingDay } from "../../index";
import { Completion } from "../../../../../shared/enums/completion.enum";

export class ShootingDaySceneDay extends BaseShootingDayScene {
    shootingDay: ShootingDay;

    constructor(obj?: {
                        id: number,
                        pageLength: number,
                        timings: string,
                        shootingDay: ShootingDay,
                        completion: Completion,
                        callsheetSceneID: number
                    }){
        super(obj);
        if(obj){
            this.shootingDay = obj.shootingDay;
        }
    }
}