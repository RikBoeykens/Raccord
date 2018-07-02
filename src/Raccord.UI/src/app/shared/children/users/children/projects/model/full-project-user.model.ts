import { BaseModel } from '../../../../..';
import { Project } from '../../../../projects';
import { User, ProjectRole } from '../../..';
import { ProjectUserCrewUnit } from '../../../../crew';
import { CastMember } from '../../../../cast';

export class FullProjectUser extends BaseModel {
  public id: number;
  public project: Project;
  public user: User;
  public castMember: CastMember;
  public projectRole: ProjectRole;
  public crewUnits: ProjectUserCrewUnit[];

  constructor(obj?: {
      id: number,
      project: Project,
      user: User,
      castMember: CastMember,
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
