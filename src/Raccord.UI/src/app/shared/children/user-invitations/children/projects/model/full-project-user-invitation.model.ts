import { BaseModel } from '../../../../..';
import { UserInvitation } from '../../..';
import { Project } from '../../../../projects';
import { ProjectRole } from '../../../../users';
import { CastMember } from '../../../../cast';
import { ProjectLinkCrewUnit } from '../../../../crew';

export class FullProjectUserInvitation extends BaseModel {
  public id: number;
  public userInvitation: UserInvitation;
  public project: Project;
  public projectRole: ProjectRole;
  public castMember: CastMember;
  public crewUnits: ProjectLinkCrewUnit[];

  constructor(obj?: {
    id: number,
    userInvitation: UserInvitation,
    project: Project,
    projectRole: ProjectRole,
    castMember: CastMember,
    crewUnits: ProjectLinkCrewUnit[]
  }) {
    super();
    if (obj) {
      this.id = obj.id;
      this.userInvitation = obj.userInvitation;
      this.project = obj.project;
      this.projectRole = obj.projectRole;
      this.castMember = obj.castMember;
      this.crewUnits = obj.crewUnits;
    }
  }
}
