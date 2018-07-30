import { BaseCallsheet } from './base-callsheet.model';
import {
    CallsheetSceneScene,
    CallsheetCharacterCharacter,
    ShootingDay,
    CallsheetBreakdown,
    CallsheetLocation
} from '../../..';
import { CrewUnit } from '../../../../shared/children/crew';
import { WeatherInfo } from '../../../../shared/children/weather';

export class FullCallsheet extends BaseCallsheet {
    public scenes: CallsheetSceneScene[];
    public characters: CallsheetCharacterCharacter[];
    public locations: CallsheetLocation[];
    public breakdownInfo: CallsheetBreakdown;
    public crewUnit: CrewUnit;
    public weatherInfo: WeatherInfo;

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
                        breakdownInfo: CallsheetBreakdown,
                        weatherInfo: WeatherInfo
                    }) {
        super(obj);
        if (obj) {
            this.scenes = obj.scenes;
            this.characters = obj.characters;
            this.locations = obj.locations;
            this.breakdownInfo = obj.breakdownInfo;
            this.crewUnit = obj.crewUnit;
            this.weatherInfo = obj.weatherInfo;
        }
    }
}
