import { BaseModel } from '../../../shared/model/base.model';
import { Project } from '../../../projects/index';
import { User } from '../../users/model/user.model';
import { CrewMember } from '../../../projects/children/crew/crew-members/model/crew-member.model';
import { ProjectRole } from '../../project-roles/model/project-role.model';
import { CastMember } from '../../../projects/children/cast/model/cast-member.model';

export class FullProjectUser extends BaseModel {
    public id: number;
    public project: Project;
    public user: User;
    public crewMembers: CrewMember[];
    public castMember: CastMember;
    public projectRole: ProjectRole;

    constructor(obj?: {
        id: number,
        project: Project,
        user: User,
        crewMembers: CrewMember[],
        castMember: CastMember,
        projectRole: ProjectRole
    }) {
        super();
        if (obj) {
            this.id = obj.id;
            this.project = obj.project;
            this.user = obj.user;
            this.crewMembers = obj.crewMembers;
            this.castMember = obj.castMember;
            this.projectRole = obj.projectRole;
        }
    }
}
