import { BaseModel } from '../../../../../shared';
import { Project } from '../../../../../projects';
import { ProjectRole } from '../../../../project-roles/model/project-role.model';

export class ProjectUserInvitationSummary extends BaseModel {
  public id: number;
  public project: Project;
  public projectRole: ProjectRole;

  constructor(obj?: {
    id: number,
    project: Project,
    projectRole: ProjectRole
  }) {
    super();
    if (obj) {
      this.id = obj.id;
      this.project = obj.project;
      this.projectRole = obj.projectRole;
    }
  }
}
