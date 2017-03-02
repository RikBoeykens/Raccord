import { Scene } from './scene.model';
import { IntExt } from '../../scene-properties/model/int-ext.model';
import { DayNight } from '../../scene-properties/model/day-night.model';
import { Location } from '../../locations/model/location.model';
import { Image } from '../../images/model/image.model';

export class SceneSummary extends Scene{
    primaryImage: Image;

    constructor(obj?: {
                        id: number,
                        number: string,
                        summary: string,
                        pageLength: number,
                        intExt: IntExt,
                        location: Location,
                        dayNight: DayNight,
                        projectId: number,
                        primaryImage: Image
                    }){
        super(obj);
        if(obj){
            this.primaryImage = obj.primaryImage;
        }
    }
}