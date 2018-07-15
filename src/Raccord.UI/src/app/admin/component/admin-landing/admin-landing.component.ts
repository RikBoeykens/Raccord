import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PagedData } from '../../../shared/children/paging';
import { AdminProjectSummary } from '../../children/projects/model/admin-project-summary.model';
import { AdminDashboard } from '../../model/admin-dashboard.model';
import { AdminUserSummary, AdminUserInvitationSummary } from '../..';
import { RouteSettings } from '../../../shared';

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

  public getProjectsLink() {
    return `/${RouteSettings.ADMIN}/${RouteSettings.PROJECTS}`;
  }

  public getProjectLink(project: AdminProjectSummary) {
    return `/${RouteSettings.ADMIN}/${RouteSettings.PROJECTS}/${project.id}`;
  }

  public getUsersLink() {
    return `/${RouteSettings.ADMIN}/${RouteSettings.USERS}`;
  }

  public getUserLink(user: AdminUserSummary) {
    return `/${RouteSettings.ADMIN}/${RouteSettings.USERS}/${user.id}`;
  }

  public getUserInvitationsLink() {
    return `/${RouteSettings.ADMIN}/${RouteSettings.INVITATIONS}`;
  }

  public getUserInvitationLink(userInvitation: AdminUserInvitationSummary) {
    return `/${RouteSettings.ADMIN}/${RouteSettings.INVITATIONS}/${userInvitation.id}`;
  }
}
