import { BaseShootingDayScene } from "./base-shooting-day-scene.model";

export class ShootingDayScene extends BaseShootingDayScene {
    shootingDayID: number;
    sceneID: number;
    locationSetID?: number;

    constructor(obj?: {
                        id: number,
                        pageLength: number,
                        timings: string,
                        completesScene: boolean,
                        shootingDayID: number,
                        sceneID: number,
                        locationSetID?: number
                    }){
        super(obj);
        if(obj){
            this.shootingDayID = obj.shootingDayID;
            this.sceneID = obj.sceneID;
            this.locationSetID = obj.locationSetID;
        }
    }
}