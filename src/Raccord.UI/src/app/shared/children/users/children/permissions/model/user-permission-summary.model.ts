// tslint:disable-next-line:max-line-length
import { ProjectPermissionSummary } from '../../project-permissions/model/project-permission-summary.model';

export class UserPermissionSummary {
    public isAdmin: boolean;
    public projectPermissions: ProjectPermissionSummary[];

    constructor(obj?: {
                        isAdmin: boolean,
                        projectPermissions: ProjectPermissionSummary[]
                    }) {
        if (obj) {
            this.isAdmin = obj.isAdmin;
            this.projectPermissions = obj.projectPermissions;
        }
    }
}
