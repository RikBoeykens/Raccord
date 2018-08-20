import { BaseModel } from '../../../../../../shared';
import { CharacterSummary } from '../../../../../../shared/children/characters';
import { CastMemberSummary } from '../../../../../../shared/children/cast';
import { CharacterCallCallType } from '../../../../..';

export class CallsheetCharacterCharacter extends BaseModel {
    public id: number;
    public character: CharacterSummary;
    public castMember: CastMemberSummary;
    public calls: CharacterCallCallType[];

    constructor(
        obj?: {
        id: number,
        character: CharacterSummary,
        castMember: CastMemberSummary,
        calls: CharacterCallCallType[]
    }) {
        super();
        if (obj) {
            this.id = obj.id;
            this.character = obj.character;
            this.castMember = obj.castMember;
            this.calls = obj.calls;
        } else {
            this.id = 0;
        }
    }
}
