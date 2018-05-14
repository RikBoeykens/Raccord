import { CrewDepartment } from './crew-department.model';
import { CrewMemberSummary } from '../../crew-members/model/crew-member-summary.model';

export class FullCrewDepartment extends CrewDepartment {
    public crewMembers: CrewMemberSummary[];

    constructor(obj?: {
                        id: number,
                        name: string,
                        description: string,
                        crewUnitID: number,
                        crewMembers: CrewMemberSummary[]
                    }) {
        super(obj);
        if (obj) {
            this.crewMembers = obj.crewMembers;
        }
    }
}