import { BaseShootingDay } from './base-shooting-day.model';
import { CrewUnit } from '../../../../../../shared/children/crew';
import { SlateSummary, ShootingDaySceneScene } from '../../../../..';

export class FullShootingDay extends BaseShootingDay {
    public crewUnit: CrewUnit;
    public previouslyCompletedSceneCount: number;
    public previouslyCompletedScenePageCount: number;
    public previouslyCompletedTimingsCount: string;
    public previousSetupCount: number;
    public scenes: ShootingDaySceneScene[];
    public slates: SlateSummary[];
    public cameraRolls: string[];
    public soundRolls: string[];

    constructor(obj?: {
                        id: number,
                        number: string,
                        date: Date,
                        start: Date,
                        turn: Date,
                        end: Date,
                        overTime: string,
                        completed: boolean,
                        scheduleDayID?: number,
                        callsheetID?: number,
                        crewUnit: CrewUnit,
                        previouslyCompletedSceneCount: number,
                        previouslyCompletedScenePageCount: number,
                        previouslyCompletedTimingsCount: string,
                        previousSetupCount: number,
                        scenes: ShootingDaySceneScene[],
                        slates: SlateSummary[],
                        cameraRolls: string[],
                        soundRolls: string[]
                    }) {
        super(obj);
        if (obj) {
            this.crewUnit = obj.crewUnit;
            this.previouslyCompletedSceneCount = obj.previouslyCompletedSceneCount;
            this.previouslyCompletedScenePageCount = obj.previouslyCompletedScenePageCount;
            this.previouslyCompletedTimingsCount = obj.previouslyCompletedTimingsCount;
            this.previousSetupCount = obj.previousSetupCount;
            this.scenes = obj.scenes;
            this.slates = obj.slates;
            this.cameraRolls = obj.cameraRolls;
            this.soundRolls = obj.soundRolls;
        }
    }
}
