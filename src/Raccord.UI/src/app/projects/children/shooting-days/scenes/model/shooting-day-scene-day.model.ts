import { BaseShootingDayScene } from "./base-shooting-day-scene.model";
import { LocationSetSummary } from "../../../locations/index";
import { ShootingDay } from "../../index";

export class ShootingDaySceneDay extends BaseShootingDayScene {
    shootingDay: ShootingDay;
    locationSet: LocationSetSummary;

    constructor(obj?: {
                        id: number,
                        pageLength: number,
                        timings: string,
                        completesScene: boolean,
                        shootingDay: ShootingDay,
                        locationSet: LocationSetSummary
                    }){
        super(obj);
        if(obj){
            this.shootingDay = obj.shootingDay;
            this.locationSet = obj.locationSet;
        }
    }
}