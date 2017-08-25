import { BaseModel } from '../../../../shared/model/base.model';

export class ShootingDay extends BaseModel{
    id: number;
    number: string;
    date: Date;
    start: Date;
    turn: Date;
    end: Date;
    overTime: string;
    completed: boolean;
    scheduleDayID?: number;
    callsheetID?: number;
    projectID: number;

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
                        projectID: number
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.number = obj.number;
            this.date = obj.date;
            this.turn = obj.turn;
            this.end = obj.end;
            this.overTime = obj.overTime;
            this.completed = obj.completed;
            this.scheduleDayID = obj.scheduleDayID;
            this.callsheetID = obj.callsheetID;
            this.projectID = obj.projectID;
        }
        else{
            this.id = 0;
        }
    }
}