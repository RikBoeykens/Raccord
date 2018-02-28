import { CrewUnit } from './crew-unit.model';
import { CrewMember } from '../../crew-members/model/crew-member.model';

export class ProjectUserCrewUnit extends CrewUnit {
    public linkID: number;
    public crewMembers: CrewMember[];

    constructor(obj?: {
                        id: number,
                        name: string,
                        description: string,
                        projectID: number,
                        linkID: number;
                        crewMembers: CrewMember[]
                    }) {
        super(obj);
        if (obj) {
            this.linkID = obj.linkID;
            this.crewMembers = obj.crewMembers;
        }
    }
}
