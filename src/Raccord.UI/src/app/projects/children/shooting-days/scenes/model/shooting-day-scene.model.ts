import { BaseShootingDayScene } from "./base-shooting-day-scene.model";
import { Completion } from "../../../../../shared/enums/completion.enum";

export class ShootingDayScene extends BaseShootingDayScene {
    shootingDayID: number;
    sceneID: number;
    locationSetID?: number;

    constructor(obj?: {
                        id: number,
                        pageLength: number,
                        timings: string,
                        shootingDayID: number,
                        sceneID: number,
                        completion: Completion,
                        callsheetSceneID: number
                    }){
        super(obj);
        if(obj){
            this.shootingDayID = obj.shootingDayID;
            this.sceneID = obj.sceneID;
        }
    }
}