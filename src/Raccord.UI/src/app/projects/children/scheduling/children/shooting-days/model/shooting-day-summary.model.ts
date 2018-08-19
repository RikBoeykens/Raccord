import { BaseShootingDay } from './base-shooting-day.model';

export class ShootingDaySummary extends BaseShootingDay {
    public totalScenes: number;
    public completedScenes: number;
    public totalPageCount: number;
    public totalTimings: string;
    public totalSetups: number;
    public crewUnitID: number;

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
                        crewUnitID: number,
                        totalScenes: number,
                        completedScenes: number,
                        totalPageCount: number,
                        totalTimings: string,
                        totalSetups: number
                    }) {
        super(obj);
        if (obj) {
            this.totalScenes = obj.totalScenes;
            this.completedScenes = obj.completedScenes;
            this.totalPageCount = obj.totalPageCount;
            this.totalTimings = obj.totalTimings;
            this.totalSetups = obj.totalSetups;
            this.crewUnitID = obj.crewUnitID;
        }
    }
}
