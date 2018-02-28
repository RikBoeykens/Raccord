import { Image } from '../children/images/model/image.model';
import { ProjectSummary } from './project-summary.model';
import { CrewMemberUnit } from '../children/crew/crew-members/model/crew-member-unit.model';

export class UserProject extends ProjectSummary {
    public crewMembers: CrewMemberUnit[];

    constructor(obj?: {id: number,
                       title: string,
                       primaryImage: Image,
                       publishedSchedule: boolean
                       crewMembers: CrewMemberUnit[]
                    }) {
        super(obj);
        if (obj) {
            this.crewMembers = obj.crewMembers;
        }
    }
}
