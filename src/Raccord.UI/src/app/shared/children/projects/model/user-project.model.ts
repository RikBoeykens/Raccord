import { ProjectSummary } from './project-summary.model';
import { Image } from '../../images/model/image.model';
import { CrewMemberUnit } from '../../crew/members/model/crew-member-unit.model';
import { Character } from '../../characters/model/character.model';

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
