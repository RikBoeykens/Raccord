import { BaseModel } from '../../../../../../shared/model/base.model';
import { Callsheet } from '../../..';
import { Scene } from '../../../../scenes/model/scene.model';
import { LinkedCharacter } from '../../../../characters/model/linked-character.model';
import { LocationSetSummary } from "../../../../locations";

export class FullCallsheetScene extends BaseModel{
    id: number;
    pageLength: number;
    scene: Scene;
    callsheet: Callsheet;
    characters: LinkedCharacter[];
    locationSet: LocationSetSummary;

    constructor(obj?: {
                        id: number, 
                        pageLength: number,
                        scene: Scene, 
                        callsheet: Callsheet,
                        characters: LinkedCharacter[],
                        locationSet: LocationSetSummary,
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.pageLength = obj.pageLength;
            this.scene = obj.scene;
            this.callsheet = obj.callsheet;
            this.characters = obj.characters;
            this.locationSet = obj.locationSet;
        }
        else{
            this.id = 0;
        }
    }
}