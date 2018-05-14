import { Image } from '../children/images/model/image.model';
import { ProjectSummary } from './project-summary.model';
import { CrewMemberUnit } from '../children/crew/crew-members/model/crew-member-unit.model';

export class UserProjectSummary extends ProjectSummary {
    public hasCrew: boolean;
    public hasCast: boolean;

    constructor(obj?: {id: number,
                       title: string,
                       primaryImage: Image,
                       hasCrew: boolean,
                       hasCast: boolean
                    }) {
        super(obj);
        if (obj) {
            this.hasCrew = obj.hasCrew;
            this.hasCast = obj.hasCast;
        }
    }
}
