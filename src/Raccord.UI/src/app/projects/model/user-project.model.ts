import { Image } from '../children/images/model/image.model';
import { ProjectSummary } from './project-summary.model';
import { CrewMemberUnit } from '../children/crew/crew-members/model/crew-member-unit.model';
import { Character } from '../children/characters/model/character.model';

export class UserProject extends ProjectSummary {
    public crewMembers: CrewMemberUnit[];
    public characters: Character[];

    constructor(obj?: {id: number,
                       title: string,
                       primaryImage: Image,
                       crewMembers: CrewMemberUnit[],
                       characters: Character[]
                    }) {
        super(obj);
        if (obj) {
            this.crewMembers = obj.crewMembers;
            this.characters = obj.characters;
        }
    }
}
