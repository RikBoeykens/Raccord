import { BaseModel } from '../../../../..';
import { ProjectSummary } from '../../../../projects';
import { ProjectRole } from '../../..';

export class ProjectUserProject extends BaseModel {
  public id: number;
  public project: ProjectSummary;
  public projectRole: ProjectRole;

  constructor(
    obj?: {
      id: number,
      project: ProjectSummary,
      projectRole: ProjectRole
    }
  ) {
    super();
    this.id = obj.id;
    this.project = obj.project;
    this.projectRole = obj.projectRole;
  }
}
