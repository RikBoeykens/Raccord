import { BaseModel } from '../../../../../shared/model/base.model';

export class ScheduleDay extends BaseModel{
    id: number;
    date: Date;
    start?: Date;
    end?: Date;
    projectId: number;

    constructor(obj?: {
                        id: number, 
                        date: Date, 
                        start?: Date, 
                        end?: Date, 
                        projectId: number
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.date = obj.date;
            this.start = obj.start;
            this.end = obj.end;
            this.projectId = obj.projectId;
        }
        else{
            this.id = 0;
        }
    }
}