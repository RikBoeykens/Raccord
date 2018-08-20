import { AdminFullUserInvitation } from '../../model/admin-full-user-invitation.model';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProjectRole } from '../../../../../shared/children/users';
import { RouteSettings } from '../../../../../shared';

@Component({
  templateUrl: 'admin-user-invitation-dashboard.component.html',
})
export class AdminUserInvitationDashboardComponent implements OnInit {
  public userInvitation: AdminFullUserInvitation;
  public projectRoles: ProjectRole[] = [];

  constructor(
    private _route: ActivatedRoute
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: {
      userInvitation: AdminFullUserInvitation,
      projectRoles: ProjectRole[]
    }) => {
      this.userInvitation = data.userInvitation;
      this.projectRoles = data.projectRoles;
    });
  }

  public getFullName() {
    return `${this.userInvitation.firstName} ${this.userInvitation.lastName}`;
  }

  public getBackLink() {
    return `/${RouteSettings.ADMIN}/${RouteSettings.INVITATIONS}`;
  }
}
