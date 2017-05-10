import { BaseModel } from '../../../../../shared/model/base.model';

export class ScheduleDayNote extends BaseModel{
    id: number;
    content: string;
    scheduleDayId: number;

    constructor(obj?: {
                        id: number, 
                        content: string, 
                        scheduleDayId: number
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.content = obj.content;
            this.scheduleDayId = obj.scheduleDayId;
        }
        else{
            this.id = 0;
        }
    }
}