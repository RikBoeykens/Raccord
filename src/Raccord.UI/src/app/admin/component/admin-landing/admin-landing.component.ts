import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PagedData } from '../../../shared/children/paging';
import { AdminProjectSummary } from '../../children/projects/model/admin-project-summary.model';
import { AdminDashboard } from '../../model/admin-dashboard.model';
import { AdminUserSummary, AdminUserInvitationSummary } from '../..';

@Component({
  selector: 'admin-landing',
  templateUrl: 'admin-landing.component.html'
})
export class AdminLandingComponent implements OnInit {
  public projects: PagedData<AdminProjectSummary>;
  public users: PagedData<AdminUserSummary>;
  public invitations: PagedData<AdminUserInvitationSummary>;
  constructor(
    private _route: ActivatedRoute
  ) {}

  public ngOnInit() {
    this._route.data.subscribe((data: {dashboardInfo: AdminDashboard}) => {
      this.projects = data.dashboardInfo.projects;
      this.users = data.dashboardInfo.users;
      this.invitations = data.dashboardInfo.invitations;
    });
  }
}
