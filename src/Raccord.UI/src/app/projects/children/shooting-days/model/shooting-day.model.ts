import { BaseModel } from '../../../../shared/model/base.model';

export class ShootingDay extends BaseModel{
    id: number;
    number: string;
    date: Date;
    callsheetId?: number;
    projectId: number;

    constructor(obj?: {
                        id: number,
                        number: string, 
                        date: Date,
                        callsheetId?: number,
                        projectId: number
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.number = obj.number;
            this.date = obj.date;
            this.callsheetId = obj.callsheetId;
            this.projectId = obj.projectId;
        }
        else{
            this.id = 0;
        }
    }
}