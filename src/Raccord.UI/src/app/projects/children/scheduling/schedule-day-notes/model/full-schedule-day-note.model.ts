import { ScheduleDayNote } from './schedule-day-note.model';

export class FullScheduleDayNote extends ScheduleDayNote{

    constructor(obj?: {
                        id: number, 
                        content: string, 
                        scheduleDayId: number
                    }){
        super();
        if(obj){
        }
        else{
            this.id = 0;
        }
    }
}