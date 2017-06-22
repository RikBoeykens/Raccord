import { SceneSummary } from './scene-summary.model';
import { IntExt } from '../../scene-properties/model/int-ext.model';
import { DayNight } from '../../scene-properties/model/day-night.model';
import { ScriptLocation } from '../../script-locations/model/script-location.model';
import { Image } from '../../images/model/image.model';

export class LinkedScene extends SceneSummary{
    linkID: number;

    constructor(obj?: {
                        id: number,
                        number: string,
                        summary: string,
                        pageLength: number,
                        intExt: IntExt,
                        scriptLocation: ScriptLocation,
                        dayNight: DayNight,
                        projectId: number,
                        primaryImage: Image,
                        linkID: number
                    }){
        super(obj);
        if(obj){
            this.linkID = obj.linkID;
        }
    }
}