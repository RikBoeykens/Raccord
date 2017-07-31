import { BaseModel } from '../../../../../../shared/model/base.model';

export class CallsheetScene extends BaseModel{
    id: number;
    pageLength: number;
    callsheetId: number;
    sceneId: number;
    locationSetId?: number;

    constructor(obj?: {
                        id: number, 
                        pageLength: number, 
                        callsheetId: number, 
                        sceneId: number,
                        locationSetId?: number
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.pageLength = obj.pageLength;
            this.callsheetId = obj.callsheetId;
            this.sceneId = obj.sceneId;
            this.locationSetId = obj.locationSetId;
        }
        else{
            this.id = 0;
        }
    }
}