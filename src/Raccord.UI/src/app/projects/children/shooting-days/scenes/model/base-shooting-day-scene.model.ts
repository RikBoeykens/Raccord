import { BaseModel } from "../../../../../shared/index";
import { Completion } from "../../../../../shared/enums/completion.enum";

export class BaseShootingDayScene extends BaseModel {
    id: number;
    pageLength: number;
    timings: string;
    completion: Completion;
    callsheetSceneID: number;

    constructor(obj?: {
                        id: number,
                        pageLength: number,
                        timings: string,
                        completion: Completion,
                        callsheetSceneID: number
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.completion = obj.completion;
            this.timings = obj.timings;
            this.pageLength = obj.pageLength;
            this.callsheetSceneID = obj.callsheetSceneID;
        }
        else{
            this.id = 0;
        }
    }
}