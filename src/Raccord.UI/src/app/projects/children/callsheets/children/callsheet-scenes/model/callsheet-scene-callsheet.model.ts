import { BaseModel } from '../../../../../../shared/model/base.model';
import { Callsheet } from '../../../';
import { LocationSetSummary } from "../../../../locations";

export class CallsheetSceneCallsheet extends BaseModel{
    id: number;
    pageLength: number;
    callsheet: Callsheet;
    locationSet: LocationSetSummary;

    constructor(obj?: {
                        id: number, 
                        pageLength: number, 
                        callsheet: Callsheet,
                        locationSet: LocationSetSummary,
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.pageLength = obj.pageLength;
            this.callsheet = obj.callsheet;
            this.locationSet = obj.locationSet;
        }
        else{
            this.id = 0;
        }
    }
}