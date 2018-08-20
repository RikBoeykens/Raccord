import { FullUser, ProjectUserProject } from '../../../../shared/children/users';

export class AdminFullUser extends FullUser {
  public projects: ProjectUserProject[];

  constructor(
    obj?: {
      id: string,
      email: string,
      firstName: string,
      lastName: string,
      hasImage: boolean,
      projects: ProjectUserProject[]
    }
  ) {
    super(obj);
    this.projects = obj.projects;
  }
}
