import { Scene } from './scene.model';
import { IntExt } from '../../scene-properties/model/int-ext.model';
import { DayNight } from '../../scene-properties/model/day-night.model';
import { Location } from '../../locations/model/location.model';

export class FullScene extends Scene{

    constructor(obj?: {
                        id: number,
                        number: string,
                        summary: string,
                        pageLength: number,
                        intExt: IntExt,
                        location: Location,
                        dayNight: DayNight,
                        projectId: number
                    }){
        super(obj);
        if(obj){
        }
    }
}