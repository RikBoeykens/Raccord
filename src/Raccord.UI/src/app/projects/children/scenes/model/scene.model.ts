import { SceneSummary } from './scene-summary.model';
import { IntExtSummary } from '../../scene-properties/model/int-ext-summary.model';
import { DayNightSummary } from '../../scene-properties/model/day-night-summary.model';
import { Location } from '../../locations/model/location.model';

export class Scene extends SceneSummary{

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
        super(obj);
        if(obj){
        }
    }
}