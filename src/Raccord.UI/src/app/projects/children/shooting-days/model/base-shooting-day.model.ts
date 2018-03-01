import { BaseModel } from '../../../../shared/model/base.model';

export class BaseShootingDay extends BaseModel {
    public id: number;
    public number: string;
    public date: Date;
    public start: Date;
    public turn: Date;
    public end: Date;
    public overTime: string;
    public completed: boolean;
    public scheduleDayID?: number;
    public callsheetID?: number;

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
                        callsheetID?: number
                    }) {
        super();
        if (obj) {
            this.id = obj.id;
            this.number = obj.number;
            this.date = obj.date;
            this.turn = obj.turn;
            this.end = obj.end;
            this.overTime = obj.overTime;
            this.completed = obj.completed;
            this.scheduleDayID = obj.scheduleDayID;
            this.callsheetID = obj.callsheetID;
        } else {
            this.id = 0;
        }
    }
}
