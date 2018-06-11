import { BaseModel } from '../../../../../shared';
import { Project } from '../../../../../projects';
import { ProjectRole } from '../../../../project-roles/model/project-role.model';
import { UserInvitation } from '../../../../../invitations/model/user-invitation.model';
import { CastMember } from '../../../../../projects/children/cast/model/cast-member.model';
import { ProjectUserCrewUnit } from '../../../../../projects/children/crew/crew-units/model/project-user-crew-unit.model';

export class FullProjectUserInvitation extends BaseModel {
  public id: number;
  public userInvitation: UserInvitation;
  public project: Project;
  public projectRole: ProjectRole;
  public castMember: CastMember;
  public crewUnits: ProjectUserCrewUnit[];

  constructor(obj?: {
    id: number,
    userInvitation: UserInvitation,
    project: Project,
    projectRole: ProjectRole,
    castMember: CastMember,
    crewUnits: ProjectUserCrewUnit[]
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
