import { ProjectRole } from '../../../../shared/children/users';
import { Project } from '../../../../shared/children/projects';
import { ProjectLinkCrewUnit } from '../../../../shared/children/crew';
import { BaseModel } from '../../../../shared';
import { AdminFullCastMember } from '../../..';
import { UserInvitation } from '../../../../shared/children/user-invitations';

export class AdminFullProjectUserInvitation extends BaseModel {
  public id: number;
  public project: Project;
  public userInvitation: UserInvitation;
  public castMember: AdminFullCastMember;
  public projectRole: ProjectRole;
  public crewUnits: ProjectLinkCrewUnit[];

  constructor(obj?: {
      id: number,
      project: Project,
      userInvitation: UserInvitation,
      castMember: AdminFullCastMember,
      projectRole: ProjectRole,
      crewUnits: ProjectLinkCrewUnit[]
  }) {
      super();
      if (obj) {
          this.id = obj.id;
          this.project = obj.project;
          this.userInvitation = obj.userInvitation;
          this.castMember = obj.castMember;
          this.projectRole = obj.projectRole;
          this.crewUnits = obj.crewUnits;
      }
  }
}
