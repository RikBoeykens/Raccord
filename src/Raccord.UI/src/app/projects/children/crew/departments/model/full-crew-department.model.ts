import { CrewDepartment } from "./crew-department.model";
import { CrewMemberSummary } from "../../crew-members/model/crew-member-summary.model";

export class FullCrewDepartment extends CrewDepartment {
    crewMembers: CrewMemberSummary[];

    constructor(obj?: {
                        id: number,
                        name: string,
                        description: string,
                        projectId: number,
                        crewMembers: CrewMemberSummary[]
                    }) {
        super(obj);
        if (obj) {
            this.crewMembers = obj.crewMembers;
        }
    }
}