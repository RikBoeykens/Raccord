import { BaseCallsheet } from './base-callsheet.model';
import { ShootingDay } from '../../shooting-days';
import { CallsheetSceneScene } from '../';
import { CallsheetCharacterCharacter } from '../';
import { CallsheetLocation } from '../../locations/locations/model/callsheet-location.model';
import { CallsheetBreakdown } from '../../breakdowns/model/callsheet-breakdown.model';
import { CrewUnit } from '../../crew/crew-units/model/crew-unit.model';

export class FullCallsheet extends BaseCallsheet {
    public scenes: CallsheetSceneScene[];
    public characters: CallsheetCharacterCharacter[];
    public locations: CallsheetLocation[];
    public breakdownInfo: CallsheetBreakdown;
    public crewUnit: CrewUnit;

    constructor(obj?: {
                        id: number,
                        start: Date,
                        end: Date,
                        crewCall: Date,
                        shootingDay: ShootingDay,
                        scenes: CallsheetSceneScene[],
                        characters: CallsheetCharacterCharacter[],
                        crewUnit: CrewUnit,
                        locations: CallsheetLocation[],
                        breakdownInfo: CallsheetBreakdown
                    }) {
        super(obj);
        if (obj) {
            this.scenes = obj.scenes;
            this.characters = obj.characters;
            this.locations = obj.locations;
            this.breakdownInfo = obj.breakdownInfo;
            this.crewUnit = obj.crewUnit;
        }
    }
}
