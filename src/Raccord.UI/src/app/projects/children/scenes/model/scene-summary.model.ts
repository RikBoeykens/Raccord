import { BaseModel } from '../../../../shared/model/base.model';
import { IntExtSummary } from '../../scene-properties/model/int-ext-summary.model';
import { DayNightSummary } from '../../scene-properties/model/day-night-summary.model';
import { Location } from '../../locations/model/location.model';

export class SceneSummary extends BaseModel{
    id: number;
    number: string;
    summary: string;
    pageLength: number;
    intExt: IntExtSummary;
    location: Location;
    dayNight: DayNightSummary;
    projectId: number;

    constructor(obj?: {
                        id: number,
                        number: string,
                        summary: string,
                        pageLength: number,
                        intExt: IntExtSummary,
                        location: Location,
                        dayNight: DayNightSummary,
                        projectId: number
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.number = obj.number;
            this.summary = obj.summary;
            this.pageLength = obj.pageLength;
            this.intExt = obj.intExt;
            this.location = obj.location;
            this.dayNight = obj.dayNight;
            this.projectId = obj.projectId;
        }else{
            this.intExt = new IntExtSummary();
            this.location = new Location();
            this.dayNight = new DayNightSummary();
        }
    }

    get displaySummary(): string{
        return `${this.number}. ${this.intExt.name} ${this.location.name} ${this.dayNight.name} - ${this.summary}`;
    }
}