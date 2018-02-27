import { CrewUnit } from './crew-unit.model';
import { LinkedProjectUserUser } from
    '../../../../../admin/project-users/model/linked-project-user-user.model';

export class FullAdminCrewUnit extends CrewUnit {
    public projectUsers: LinkedProjectUserUser[];

    constructor(obj?: {
                        id: number,
                        name: string,
                        description: string,
                        projectID: number,
                        projectUsers: LinkedProjectUserUser[]
                    }) {
        super(obj);
        if (obj) {
            this.projectUsers = obj.projectUsers;
        }
    }
}
