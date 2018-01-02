import { CrewDepartment } from '../../departments/model/crew-department.model';
import { CrewMember } from './crew-member.model';

export class CrewMemberSummary extends CrewMember {
    userID: string;
    hasImage: boolean;

    constructor(obj?: {
                        id: number,
                        firstName: string,
                        lastName: string,
                        jobTitle: string,
                        email: string,
                        telephone: string,
                        department: CrewDepartment,
                        userID: string,
                        hasImage: boolean
                    }) {
        super(obj);
        this.userID = obj.userID;
        this.hasImage = obj.hasImage;
    }
}