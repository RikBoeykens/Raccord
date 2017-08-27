import { BaseShootingDayScene } from "./base-shooting-day-scene.model";
import { SceneSummary } from "../../../scenes/model/scene-summary.model";
import { LocationSetSummary } from "../../../locations/index";
import { Completion } from "../../../../../shared/enums/completion.enum";

export class ShootingDaySceneScene extends BaseShootingDayScene {
    scenePageLength: number;
    sceneTimings: string;
    previousPageLength: number;
    previousTimings: string;
    plannedPageLength: number;
    completedByOther: boolean;
    scene: SceneSummary;

    constructor(obj?: {
                        id: number,
                        pageLength: number,
                        timings: string,
                        scenePageLength: number,
                        sceneTimings: string,
                        previousPageLength: number,
                        previousTimings: string,
                        plannedPageLength: number,
                        completedByOther: boolean,
                        scene: SceneSummary,
                        completion: Completion,
                        callsheetSceneID: number
                    }){
        super(obj);
        if(obj){
            this.scenePageLength = obj.scenePageLength;
            this.sceneTimings = obj.sceneTimings;
            this.previousPageLength = obj.previousPageLength;
            this.previousTimings = obj.previousTimings;
            this.plannedPageLength = obj.plannedPageLength;
            this.completedByOther = obj.completedByOther;
            this.scene = obj.scene;
        }
    }
}