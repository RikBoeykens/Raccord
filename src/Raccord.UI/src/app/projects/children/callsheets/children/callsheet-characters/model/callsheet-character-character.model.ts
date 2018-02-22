import { BaseModel } from '../../../../../../shared/model/base.model';
import { CharacterCallCallType } from "../../../";
import { CharacterSummary } from "../../../../characters/model/character-summary.model";
import { CastMemberSummary } from '../../../../cast/model/cast-member-summary.model';

export class CallsheetCharacterCharacter extends BaseModel{
    id: number;
    character: CharacterSummary;
    castMember: CastMemberSummary;
    calls: CharacterCallCallType[];

    constructor(obj?: {
                        id: number, 
                        character: CharacterSummary,
                        castMember: CastMemberSummary, 
                        calls: CharacterCallCallType[]
                    }){
        super();
        if(obj){
            this.id = obj.id;
            this.character = obj.character;
            this.castMember = obj.castMember;
            this.calls = obj.calls;
        }
        else{
            this.id = 0;
        }
    }
}