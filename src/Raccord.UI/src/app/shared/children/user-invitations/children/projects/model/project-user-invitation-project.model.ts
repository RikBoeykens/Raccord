import { ProjectSummary } from '../../../../projects';
import { ProjectRole } from '../../../../users';
import {
  ProjectUserInvitationSummary
} from './project-user-invitation-summary.model';

export class ProjectUserInvitationProject extends ProjectUserInvitationSummary {
  public project: ProjectSummary;

  constructor(
    obj?: {
      id: number,
      projectRole: ProjectRole,
      project: ProjectSummary
    }
  ) {
    super(obj);
    if (obj) {
      this.project = obj.project;
    }
  }
}
