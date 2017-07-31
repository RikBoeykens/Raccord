import { Callsheet } from './callsheet.model';
import { ShootingDay } from "../../shooting-days";
import { CallsheetSceneScene } from "../";
import { CallsheetCharacterCharacter } from "../";

export class FullCallsheet extends Callsheet{
    scenes: CallsheetSceneScene[];
    characters: CallsheetCharacterCharacter[];

    constructor(obj?: {
                        id: number,
                        start: Date,
                        end: Date,
                        crewCall: Date,
                        shootingDay: ShootingDay,
                        scenes: CallsheetSceneScene[],
                        characters: CallsheetCharacterCharacter[],
                        projectId: number,
                    }){
        super(obj);
        if(obj){
            this.scenes = obj.scenes;
            this.characters = obj.characters;
        }
    }
}