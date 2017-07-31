import { BaseModel } from '../../../../../../shared/model/base.model';
import { Callsheet } from '../../../';
import { Scene } from '../../../../scenes/model/scene.model';
import { LocationSetSummary } from "../../../../locations";

export class CallsheetSceneSummary extends BaseModel{
    id: number;
    pageLength: number;
    scene: Scene;
    callsheet: Callsheet;
    locationSet: LocationSetSummary;

    constructor(obj?: {
                        id: number, 
                        pageLength: number,
                        scene: Scene, 
                        callsheet: Callsheet,
                        locationSet: LocationSetSummary,
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.pageLength = obj.pageLength;
            this.scene = obj.scene;
            this.callsheet = obj.callsheet;
            this.locationSet = obj.locationSet;
        }
        else{
            this.id = 0;
        }
    }
}