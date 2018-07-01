import { ProjectPermissionEnum } from '../enums/project-permission.enum';

export class ProjectPermissionSummary {
  public projectID: number;
  public projectPermissions: ProjectPermissionEnum[];

  constructor(obj?: {
    projectID: number,
    projectPermissions: ProjectPermissionEnum[]
                  }) {
      if (obj) {
          this.projectID = obj.projectID;
          this.projectPermissions = obj.projectPermissions;
      }
  }
}
