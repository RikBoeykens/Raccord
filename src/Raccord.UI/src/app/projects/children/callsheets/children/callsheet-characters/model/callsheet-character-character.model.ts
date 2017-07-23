import { BaseModel } from '../../../../../../shared/model/base.model';
import { CharacterCallCallType } from "../../../";
import { CharacterSummary } from "../../../../characters/model/character-summary.model";

export class CallsheetCharacterCharacter extends BaseModel{
    id: number;
    character: CharacterSummary;
    calls: CharacterCallCallType[];

    constructor(obj?: {
                        id: number, 
                        character: CharacterSummary, 
                        calls: CharacterCallCallType[]
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.character = obj.character;
            this.calls = obj.calls;
        }
        else{
            this.id = 0;
        }
    }
}