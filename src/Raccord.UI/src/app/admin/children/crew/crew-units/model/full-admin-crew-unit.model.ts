import { CrewUnit } from '../../../../../shared/children/crew';
import { LinkedProjectUserUser } from '../../../../../shared/children/users';

export class FullAdminCrewUnit extends CrewUnit {
  public projectUsers: LinkedProjectUserUser[];

  constructor(
    obj?: {
    id: number,
    name: string,
    description: string,
    projectID: number,
    projectUsers: LinkedProjectUserUser[]
  }) {
    super(obj);
    if (obj) {
      this.projectUsers = this.projectUsers;
    }
  }
}
