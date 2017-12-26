import { BaseModel } from '../../../../shared/model/base.model';
import { Scene } from '../../scenes/model/scene.model';
import { Character } from '../../characters/model/character.model';
import { ScriptLocation } from '../../script-locations/model/script-location.model';

export class FullScriptUpload extends BaseModel{
    id: number;
    fileName: string;
    start: Date;
    end?: Date;
    scenes: Scene[];
    characters: Character[];
    scriptLocations: ScriptLocation[];
    projectID: number;

    constructor(obj?: {
                        id: number,
                        fileName: string,
                        start: Date,
                        end?: Date,
                        scenes: Scene[],
                        characters: Character[],
                        scriptLocations: ScriptLocation[],
                        projectID: number
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.fileName = obj.fileName;
            this.start = obj.start;
            this.end = obj.end;
            this.scenes = obj.scenes;
            this.characters = obj.characters;
            this.scriptLocations = obj.scriptLocations;
            this.projectID = obj.projectID;
        }
        else{
            this.id = 0;
        }
    }
}