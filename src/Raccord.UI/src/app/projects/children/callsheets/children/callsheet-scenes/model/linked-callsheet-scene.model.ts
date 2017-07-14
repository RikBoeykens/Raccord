import { CallsheetSceneSummary } from "../model/callsheet-scene-summary.model";
import { Callsheet } from '../../..';
import { Scene } from '../../../../scenes/model/scene.model';
import { LocationSetSummary } from "../../../../locations";

export class LinkedCallsheetScene extends CallsheetSceneSummary{
    linkID: number;

    constructor(obj?: {
                        id: number, 
                        pageLength: number,
                        scene: Scene, 
                        callsheet: Callsheet,
                        linkID: number,
                        locationSet: LocationSetSummary
                    }){
        super(obj);
        if(obj){
            this.linkID = obj.linkID;
        }
    }
}