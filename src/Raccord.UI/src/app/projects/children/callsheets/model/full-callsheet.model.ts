import { Callsheet } from './callsheet.model';
import { ShootingDay } from '../../shooting-days';
import { CallsheetSceneScene } from '../';
import { CallsheetCharacterCharacter } from '../';
import { CallsheetLocation } from '../../locations/locations/model/callsheet-location.model';
import { CallsheetBreakdown } from '../../breakdowns/model/callsheet-breakdown.model';

export class FullCallsheet extends Callsheet {
    public scenes: CallsheetSceneScene[];
    public characters: CallsheetCharacterCharacter[];
    public locations: CallsheetLocation[];
    public breakdownInfo: CallsheetBreakdown;

    constructor(obj?: {
                        id: number,
                        start: Date,
                        end: Date,
                        crewCall: Date,
                        shootingDay: ShootingDay,
                        scenes: CallsheetSceneScene[],
                        characters: CallsheetCharacterCharacter[],
                        projectId: number,
                        locations: CallsheetLocation[],
                        breakdownInfo: CallsheetBreakdown
                    }) {
        super(obj);
        if (obj) {
            this.scenes = obj.scenes;
            this.characters = obj.characters;
            this.locations = obj.locations;
            this.breakdownInfo = obj.breakdownInfo;
        }
    }
}
