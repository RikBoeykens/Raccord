import { BaseShootingDayScene } from "./base-shooting-day-scene.model";
import { SceneSummary } from "../../../scenes/model/scene-summary.model";
import { LocationSetSummary } from "../../../locations/index";

export class ShootingDaySceneScene extends BaseShootingDayScene {
    scenePageLength: number;
    sceneTimings: string;
    previousPageLength: number;
    previousTimings: string;
    scene: SceneSummary;
    locationSet: LocationSetSummary;

    constructor(obj?: {
                        id: number,
                        pageLength: number,
                        timings: string,
                        completesScene: boolean,
                        scenePageLength: number,
                        sceneTimings: string,
                        previousPageLength: number,
                        previousTimings: string,
                        scene: SceneSummary,
                        locationSet: LocationSetSummary
                    }){
        super(obj);
        if(obj){
            this.scenePageLength = obj.scenePageLength;
            this.sceneTimings = obj.sceneTimings;
            this.previousPageLength = obj.previousPageLength;
            this.previousTimings = obj.previousTimings;
            this.scene = obj.scene;
            this.locationSet = obj.locationSet;
        }
    }
}