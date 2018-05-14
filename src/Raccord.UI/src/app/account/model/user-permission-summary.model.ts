import { ProjectPermissionSummary } from "../../shared/children/users/project-roles/model/project-permission-summary.model";

export class UserPermissionSummary{
    isAdmin: boolean;
    projectPermissions: ProjectPermissionSummary[];

    constructor(obj?: {
                        isAdmin: boolean,
                        projectPermissions: ProjectPermissionSummary[]
                    }){
        if(obj){
            this.isAdmin = obj.isAdmin;
            this.projectPermissions = obj.projectPermissions;
        }
    }
}