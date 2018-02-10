import { Scene } from './scene.model';
import { IntExt } from '../../scene-properties/model/int-ext.model';
import { DayNight } from '../../scene-properties/model/day-night.model';
import { ScriptLocation } from '../../script-locations/model/script-location.model';
import { LinkedImage } from '../../images/model/linked-image.model';
import { LinkedCharacter } from '../../characters/model/linked-character.model';
import { LinkedBreakdownItem } from '../../breakdowns/children/breakdown-items/model/linked-breakdown-item.model';
import { SlateSummary } from "../../shots/slates/model/slate-summary.model";
import { ShootingDayInfo } from '../../shooting-days/model/shooting-day-info';

export class FullScene extends Scene{
    images: LinkedImage[];
    characters: LinkedCharacter[];
    breakdownItems: LinkedBreakdownItem[];
    shootingDays: ShootingDayInfo[];
    slates: SlateSummary[];

    constructor(obj?: {
                        id: number,
                        number: string,
                        summary: string,
                        pageLength: number,
                        timing: string,
                        intExt: IntExt,
                        scriptLocation: ScriptLocation,
                        dayNight: DayNight,
                        projectId: number,
                        images: LinkedImage[],
                        characters: LinkedCharacter[],
                        breakdownItems: LinkedBreakdownItem[],
                        shootingDays: ShootingDayInfo[],
                        slates: SlateSummary[]
                    }){
        super(obj);
        if(obj){
            this.images = obj.images;
            this.characters = obj.characters;
            this.breakdownItems = obj.breakdownItems;
            this.shootingDays = obj.shootingDays;
            this.slates = obj.slates;
        }
    }
}