import { BaseModel } from '../../../../shared/model/base.model';
import { IntExt } from '../../scene-properties/model/int-ext.model';
import { DayNight } from '../../scene-properties/model/day-night.model';
import { ScriptLocation } from '../../script-locations/model/script-location.model';

export class Scene extends BaseModel{
    id: number;
    number: string;
    summary: string;
    pageLength: number;
    intExt: IntExt;
    scriptLocation: ScriptLocation;
    dayNight: DayNight;
    projectId: number;

    constructor(obj?: {
                        id: number,
                        number: string,
                        summary: string,
                        pageLength: number,
                        intExt: IntExt,
                        scriptLocation: ScriptLocation,
                        dayNight: DayNight,
                        projectId: number
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.number = obj.number;
            this.summary = obj.summary;
            this.pageLength = obj.pageLength;
            this.intExt = obj.intExt;
            this.scriptLocation = obj.scriptLocation;
            this.dayNight = obj.dayNight;
            this.projectId = obj.projectId;
        }else{
            this.intExt = new IntExt();
            this.scriptLocation = new ScriptLocation();
            this.dayNight = new DayNight();
        }
    }

    get displaySummary(): string{
        return `${this.number}. ${this.intExt.name} ${this.scriptLocation.name} ${this.dayNight.name} - ${this.summary}`;
    }
}