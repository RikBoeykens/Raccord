import { Scene } from './scene.model';
import { IntExt } from '../../scene-properties/model/int-ext.model';
import { DayNight } from '../../scene-properties/model/day-night.model';
import { Location } from '../../locations/model/location.model';
import { LinkedImage } from '../../images/model/linked-image.model';
import { LinkedCharacter } from '../../characters/model/linked-character.model';
import { LinkedBreakdownItem } from '../../breakdowns/breakdown-items/model/linked-breakdown-item.model';

export class FullScene extends Scene{
    images: LinkedImage[];
    characters: LinkedCharacter[];
    breakdownItems: LinkedBreakdownItem[];

    constructor(obj?: {
                        id: number,
                        number: string,
                        summary: string,
                        pageLength: number,
                        intExt: IntExt,
                        location: Location,
                        dayNight: DayNight,
                        projectId: number,
                        images: LinkedImage[],
                        characters: LinkedCharacter[],
                        breakdownItems: LinkedBreakdownItem[],
                    }){
        super(obj);
        if(obj){
            this.images = obj.images;
            this.characters = obj.characters;
            this.breakdownItems = obj.breakdownItems;
        }
    }
}