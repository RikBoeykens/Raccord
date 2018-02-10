import { Callsheet } from './callsheet.model';
import { ShootingDay } from "../../shooting-days";
import { CallsheetSceneScene } from "../";
import { CallsheetCharacterCharacter } from "../";
import { CallsheetLocation } from '../../locations/locations/model/callsheet-location.model';
import { CallsheetBreakdownType } from '../../breakdowns/children/breakdown-types/model/callsheet-breakdown-type.model';

export class FullCallsheet extends Callsheet{
    scenes: CallsheetSceneScene[];
    characters: CallsheetCharacterCharacter[];
    locations: CallsheetLocation[];
    breakdownTypes: CallsheetBreakdownType[];

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
                        breakdownTypes: CallsheetBreakdownType[]
                    }){
        super(obj);
        if(obj){
            this.scenes = obj.scenes;
            this.characters = obj.characters;
            this.locations = obj.locations;
            this.breakdownTypes = obj.breakdownTypes;
        }
    }
}