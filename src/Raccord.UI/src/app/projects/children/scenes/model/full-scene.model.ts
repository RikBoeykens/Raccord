import { Scene } from './scene.model';
import { IntExt } from '../../scene-properties/model/int-ext.model';
import { DayNight } from '../../scene-properties/model/day-night.model';
import { ScriptLocation } from '../../script-locations/model/script-location.model';
import { LinkedImage } from '../../images/model/linked-image.model';
import { LinkedCharacter } from '../../characters/model/linked-character.model';
import { SlateSummary } from '../../shots/slates/model/slate-summary.model';
import { ShootingDayInfo } from '../../shooting-days/model/shooting-day-info';
import { SceneBreakdown } from '../../breakdowns/model/scene-breakdown.model';

export class FullScene extends Scene {
    public images: LinkedImage[];
    public characters: LinkedCharacter[];
    public breakdownInfo: SceneBreakdown;
    public shootingDays: ShootingDayInfo[];
    public slates: SlateSummary[];

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
                        breakdownInfo: SceneBreakdown,
                        shootingDays: ShootingDayInfo[],
                        slates: SlateSummary[]
                    }) {
        super(obj);
        if (obj) {
            this.images = obj.images;
            this.characters = obj.characters;
            this.breakdownInfo = obj.breakdownInfo;
            this.shootingDays = obj.shootingDays;
            this.slates = obj.slates;
        }
    }
}
