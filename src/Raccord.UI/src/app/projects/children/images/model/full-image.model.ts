import { Image } from './image.model';
import { LinkedScene } from '../../scenes/model/linked-scene.model';
import { LinkedScriptLocation } from '../../script-locations/model/linked-script-location.model';
import { LinkedCharacter } from '../../characters/model/linked-character.model';
import { LinkedBreakdownItem } from '../../breakdowns/children/breakdown-items/model/linked-breakdown-item.model';
import { LinkedSlate } from "../../shots/slates/model/linked-slate.model";

export class FullImage extends Image{
    isPrimary: boolean;
    scenes: LinkedScene[];
    scriptLocations: LinkedScriptLocation[];
    characters: LinkedCharacter[];
    breakdownItems: LinkedBreakdownItem[];
    slates: LinkedSlate[];

    constructor(obj?: {
                        id: number, 
                        title: string, 
                        description: string,
                        fileName: string,
                        projectId: number,
                        isPrimary: boolean,
                        scenes: LinkedScene[],
                        scriptLocations: LinkedScriptLocation[],
                        characters: LinkedCharacter[],
                        breakdownItems: LinkedBreakdownItem[],
                        slates: LinkedSlate[]
                    }){
        super(obj);
        if(obj){
            this.isPrimary = obj.isPrimary;
            this.scenes = obj.scenes;
            this.scriptLocations = obj.scriptLocations;
            this.characters = obj.characters;
            this.breakdownItems = obj.breakdownItems;
            this.slates = obj.slates;
        }
    }
}