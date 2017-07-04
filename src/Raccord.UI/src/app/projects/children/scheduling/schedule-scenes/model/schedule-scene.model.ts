import { BaseModel } from '../../../../../shared/model/base.model';

export class ScheduleScene extends BaseModel{
    id: number;
    pageLength: number;
    scheduleDayId: number;
    sceneId: number;
    locationSetId?: number;

    constructor(obj?: {
                        id: number, 
                        pageLength: number, 
                        scheduleDayId: number, 
                        sceneId: number,
                        locationSetId?: number
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.pageLength = obj.pageLength;
            this.scheduleDayId = obj.scheduleDayId;
            this.sceneId = obj.sceneId;
            this.locationSetId = obj.locationSetId;
        }
        else{
            this.id = 0;
        }
    }
}