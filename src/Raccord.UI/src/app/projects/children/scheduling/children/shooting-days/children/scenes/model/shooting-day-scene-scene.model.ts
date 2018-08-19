import { BaseShootingDayScene } from './base-shooting-day-scene.model';
import { SceneSummary } from '../../../../../../../../shared/children/scenes';
import { LocationSetLocation } from '../../../../../../..';
import { Completion } from '../../../../../../../../shared';

export class ShootingDaySceneScene extends BaseShootingDayScene {
    public scenePageLength: number;
    public sceneTimings: string;
    public previousPageLength: number;
    public previousTimings: string;
    public plannedPageLength: number;
    public completedByOther: boolean;
    public scene: SceneSummary;
    public locationSet: LocationSetLocation;
    public availableLocationSets: LocationSetLocation[];

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
                        callsheetSceneID: number,
                        locationSet: LocationSetLocation,
                        availableLocationSets: LocationSetLocation[];
                    }) {
        super(obj);
        if (obj) {
            this.scenePageLength = obj.scenePageLength;
            this.sceneTimings = obj.sceneTimings;
            this.previousPageLength = obj.previousPageLength;
            this.previousTimings = obj.previousTimings;
            this.plannedPageLength = obj.plannedPageLength;
            this.completedByOther = obj.completedByOther;
            this.scene = obj.scene;
            this.locationSet = obj.locationSet;
            this.availableLocationSets = obj.availableLocationSets;
        }
    }
}
