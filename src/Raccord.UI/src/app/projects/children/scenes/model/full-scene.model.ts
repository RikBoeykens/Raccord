import { Scene } from './scene.model';
import { IntExt } from '../../scene-properties/model/int-ext.model';
import { DayNight } from '../../scene-properties/model/day-night.model';
import { ScriptLocation } from '../../script-locations/model/script-location.model';
import { LinkedImage } from '../../images/model/linked-image.model';
import { LinkedCharacter } from '../../characters/model/linked-character.model';
import { LinkedBreakdownItem } from '../../breakdowns/breakdown-items/model/linked-breakdown-item.model';
import { ScheduleSceneDay } from '../../scheduling/schedule-scenes/model/schedule-scene-day.model';

export class FullScene extends Scene{
    images: LinkedImage[];
    characters: LinkedCharacter[];
    breakdownItems: LinkedBreakdownItem[];
    scheduleDays: ScheduleSceneDay[];

    constructor(obj?: {
                        id: number,
                        number: string,
                        summary: string,
                        pageLength: number,
                        intExt: IntExt,
                        scriptLocation: ScriptLocation,
                        dayNight: DayNight,
                        projectId: number,
                        images: LinkedImage[],
                        characters: LinkedCharacter[],
                        breakdownItems: LinkedBreakdownItem[],
                        scheduleDays: ScheduleSceneDay[],
                    }){
        super(obj);
        if(obj){
            this.images = obj.images;
            this.characters = obj.characters;
            this.breakdownItems = obj.breakdownItems;
            this.scheduleDays = obj.scheduleDays;
        }
    }
}