import { BaseModel } from '../../../../..';
import { ProjectSummary } from '../../../../projects';
import { ProjectRole } from '../../..';

export class ProjectUserProject extends BaseModel {
  public ID: number;
  public project: ProjectSummary;
  public projectRole: ProjectRole;

  constructor(
    obj?: {
      ID: number,
      project: ProjectSummary,
      projectRole: ProjectRole
    }
  ) {
    super();
    this.ID = obj.ID;
    this.project = obj.project;
    this.projectRole = obj.projectRole;
  }
}
