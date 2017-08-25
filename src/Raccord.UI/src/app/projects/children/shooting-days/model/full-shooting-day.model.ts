import { ShootingDay } from "./shooting-day.model";
import { SlateSummary } from "../../shots/slates/model/slate-summary.model";
import { ShootingDaySceneScene } from "../scenes/model/shooting-day-scene-scene.model";

export class FullShootingDay extends ShootingDay{
    previouslyCompletedSceneCount: number;
    previouslyCompletedScenePageCount: number;
    previouslyCompletedTimingsCount: string;
    scenes: ShootingDaySceneScene[];
    slates: SlateSummary[];
    cameraRolls: string[];
    soundRolls: string[];

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
                        projectID: number,
                        previouslyCompletedSceneCount: number,
                        previouslyCompletedScenePageCount: number,
                        previouslyCompletedTimingsCount: string,
                        scenes: ShootingDaySceneScene[],
                        slates: SlateSummary[],
                        cameraRolls: string[],
                        soundRolls: string[]
                    }){
        super(obj);
        if(obj){
            this.previouslyCompletedSceneCount = obj.previouslyCompletedSceneCount;
            this.previouslyCompletedScenePageCount = obj.previouslyCompletedScenePageCount;
            this.previouslyCompletedTimingsCount = obj.previouslyCompletedTimingsCount;
            this.scenes = obj.scenes;
            this.slates = obj.slates;
            this.cameraRolls = obj.cameraRolls;
            this.soundRolls = obj.soundRolls;
        }
    }
}