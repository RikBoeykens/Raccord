import { CrewDepartment } from '../../departments/model/crew-department.model';
import { CrewMember } from './crew-member.model';

export class CrewMemberSummary extends CrewMember {

    constructor(obj?: {
                        id: number,
                        firstName: string,
                        lastName: string,
                        jobTitle: string,
                        email: string,
                        telephone: string,
                        department: CrewDepartment
                    }) {
        super(obj);
    }
}