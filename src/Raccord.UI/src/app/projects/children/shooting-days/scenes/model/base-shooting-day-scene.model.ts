import { BaseModel } from "../../../../../shared/index";

export class BaseShootingDayScene extends BaseModel {
    id: number;
    pageLength: number;
    timings: string;
    completesScene: boolean;

    constructor(obj?: {
                        id: number,
                        pageLength: number,
                        timings: string,
                        completesScene: boolean
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.completesScene = obj.completesScene;
            this.timings = obj.timings;
            this.pageLength = obj.pageLength;
        }
        else{
            this.id = 0;
        }
    }
}