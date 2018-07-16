import { User, ProjectRole } from '../../../../shared/children/users';
import { Project } from '../../../../shared/children/projects';
import { CastMember } from '../../../../shared/children/cast';
import { ProjectUserCrewUnit } from '../../../../shared/children/crew';
import { BaseModel } from '../../../../shared';
import { AdminFullCastMember } from '../../..';

export class AdminFullProjectUser extends BaseModel {
  public id: number;
  public project: Project;
  public user: User;
  public castMember: AdminFullCastMember;
  public projectRole: ProjectRole;
  public crewUnits: ProjectUserCrewUnit[];

  constructor(obj?: {
      id: number,
      project: Project,
      user: User,
      castMember: AdminFullCastMember,
      projectRole: ProjectRole,
      crewUnits: ProjectUserCrewUnit[]
  }) {
      super();
      if (obj) {
          this.id = obj.id;
          this.project = obj.project;
          this.user = obj.user;
          this.castMember = obj.castMember;
          this.projectRole = obj.projectRole;
          this.crewUnits = obj.crewUnits;
      }
  }
}
