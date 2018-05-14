import { BaseModel } from '../../../shared/model/base.model';
import { Project } from '../../../projects/index';
import { User } from '../../users/model/user.model';
import { CrewMember } from '../../../projects/children/crew/crew-members/model/crew-member.model';
import { ProjectRole } from '../../project-roles/model/project-role.model';
import { CastMember } from '../../../projects/children/cast/model/cast-member.model';
import { ProjectUserCrewUnit }
    from '../../../projects/children/crew/crew-units/model/project-user-crew-unit.model';

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
