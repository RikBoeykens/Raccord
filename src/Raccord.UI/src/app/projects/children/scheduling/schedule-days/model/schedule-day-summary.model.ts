import { ScheduleDay } from './schedule-day.model';

export class ScheduleDaySummary extends ScheduleDay{
    sceneCount: number;
    pageLength: number;

    constructor(obj?: {
                        id: number, 
                        date: Date, 
                        start?: Date, 
                        end?: Date, 
                        projectId: number,
                        sceneCount: number,
                        pageLength: number
                    }){
        super(obj);
        if(obj){
            this.sceneCount = obj.sceneCount;
            this.pageLength = obj.pageLength;
        }
        else{
            this.id = 0;
        }
    }
}