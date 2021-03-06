import { BaseModel } from '../../../../../model/base.model';
import { ProjectRoleEnum } from '../../../../../enums/project-role.enum';

export class ProjectRole extends BaseModel {
  public id: number;
  public name: string;
  public description: string;
  public role: ProjectRoleEnum;

  constructor(
    obj?: {
      id: number,
      name: string,
      description: string,
      role: ProjectRoleEnum
    }
  ) {
    super();
    if (obj) {
      this.id = obj.id;
      this.name = obj.name;
      this.description = obj.description;
      this.role = obj.role;
    }
  }
}
