import { BaseModel } from '../../shared';
import { PagedData } from '../../shared/children/paging';
import { AdminProjectSummary } from '../children/projects/model/admin-project-summary.model';
import { AdminUserSummary } from '../children/users/model/admin-user-summary.model';
// tslint:disable-next-line:max-line-length
import { AdminUserInvitationSummary } from '../children/user-invitations/model/admin-user-invitation-summary.model';

export class AdminDashboard extends BaseModel {
  public projects: PagedData<AdminProjectSummary>;
  public users: PagedData<AdminUserSummary>;
  public invitations: PagedData<AdminUserInvitationSummary>;

  constructor(
    obj?: {
      projects: PagedData<AdminProjectSummary>,
      users: PagedData<AdminUserSummary>,
      invitations: PagedData<AdminUserInvitationSummary>
  }) {
    super();
    if (obj) {
      this.projects = obj.projects;
      this.users = obj.users;
      this.invitations = obj.invitations;
    }
  }
}
