import { BaseModel } from '../../../../../shared/index';
import { CrewDepartment } from '../../departments/model/crew-department.model';

export class CrewMember extends BaseModel {
    id: number;
    firstName: string;
    lastName: string;
    jobTitle: string;
    email: string;
    telephone: string;
    department: CrewDepartment;

    constructor(obj?: {
                        id: number,
                        firstName: string,
                        lastName: string,
                        jobTitle: string,
                        email: string,
                        telephone: string,
                        department: CrewDepartment
                    }) {
        super();
        if (obj) {
            this.id = obj.id;
            this.firstName = obj.firstName;
            this.lastName = obj.lastName;
            this.jobTitle = obj.jobTitle;
            this.email = obj.email;
            this.telephone = obj.telephone;
            this.department = obj.department;
        }
        else {
            this.id = 0;
        }
    }
}