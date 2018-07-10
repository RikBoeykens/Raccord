import { BaseModel } from '../../shared';
import { PagedData } from '../../shared/children/paging';
import { AdminProjectSummary } from '../children/projects/model/admin-project-summary.model';

export class AdminDashboard extends BaseModel {
  public projects: PagedData<AdminProjectSummary>;

  constructor(
    obj?: {
      projects: PagedData<AdminProjectSummary>
  }) {
    super();
    if (obj) {
      this.projects = obj.projects;
    }
  }
}
