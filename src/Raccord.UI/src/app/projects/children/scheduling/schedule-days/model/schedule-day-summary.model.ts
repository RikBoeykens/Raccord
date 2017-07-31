import { ScheduleDay } from './schedule-day.model';
import { ShootingDay } from "../../../shooting-days";

export class ScheduleDaySummary extends ScheduleDay{
    sceneCount: number;
    pageLength: number;
    shootingDay: ShootingDay;

    constructor(obj?: {
                        id: number, 
                        date: Date, 
                        start?: Date, 
                        end?: Date, 
                        projectId: number,
                        sceneCount: number,
                        pageLength: number,
                        shootingDay: ShootingDay
                    }){
        super(obj);
        if(obj){
            this.sceneCount = obj.sceneCount;
            this.pageLength = obj.pageLength;
            this.shootingDay = obj.shootingDay;
        }
        else{
            this.id = 0;
        }
    }
}