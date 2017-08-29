import { ShootingDay } from "./shooting-day.model";

export class ShootingDaySummary extends ShootingDay{
    totalScenes: number;
    completedScenes: number;
    totalPageCount: number;
    totalTimings: string;
    totalSetups: number;

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
                        totalScenes: number,
                        completedScenes: number,
                        totalPageCount: number,
                        totalTimings: string,
                        totalSetups: number
                    }){
        super(obj);
        if(obj){
            this.totalScenes = obj.totalScenes;
            this.completedScenes = obj.completedScenes;
            this.totalPageCount = obj.totalPageCount;
            this.totalTimings = obj.totalTimings;
            this.totalSetups = obj.totalSetups;
        }
    }
}