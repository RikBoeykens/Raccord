import { BaseModel } from '../../../../shared/model/base.model';

export class ShootingDay extends BaseModel{
    id: number;
    number: string;
    date: Date;
    projectId: number;

    constructor(obj?: {
                        id: number,
                        number: string, 
                        date: Date,
                        projectId: number
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.number = obj.number;
            this.date = obj.date;
            this.projectId = obj.projectId;
        }
        else{
            this.id = 0;
        }
    }
}