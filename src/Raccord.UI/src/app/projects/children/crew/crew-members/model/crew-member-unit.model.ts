import { CrewDepartment } from '../../departments/model/crew-department.model';
import { CrewMember } from './crew-member.model';
import { CrewUnit } from '../../crew-units/model/crew-unit.model';

export class CrewMemberUnit extends CrewMember {
    public crewUnit: CrewUnit;

    constructor(obj?: {
                        id: number,
                        firstName: string,
                        lastName: string,
                        jobTitle: string,
                        email: string,
                        telephone: string,
                        department: CrewDepartment,
                        crewUnit: CrewUnit
                    }) {
        super(obj);
        if (obj) {
            this.crewUnit = obj.crewUnit;
        }
    }
}
