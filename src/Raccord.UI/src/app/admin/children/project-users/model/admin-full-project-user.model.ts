import { FullProjectUser, User, ProjectRole } from '../../../../shared/children/users';
import { Project } from '../../../../shared/children/projects';
import { CastMember } from '../../../../shared/children/cast';
import { ProjectUserCrewUnit } from '../../../../shared/children/crew';

export class AdminFullProjectUser extends FullProjectUser {
  constructor(obj?: {
    id: number,
    project: Project,
    user: User,
    castMember: CastMember,
    projectRole: ProjectRole,
    crewUnits: ProjectUserCrewUnit[]
  }) {
    super(obj);
  }
}
