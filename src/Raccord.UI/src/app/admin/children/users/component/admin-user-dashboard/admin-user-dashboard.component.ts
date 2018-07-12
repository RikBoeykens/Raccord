import { AdminFullUser } from '../../model/admin-full-user.model';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProjectRole } from '../../../../../shared/children/users';

@Component({
  templateUrl: 'admin-user-dashboard.component.html',
})
export class AdminUserDashboardComponent implements OnInit {
  public user: AdminFullUser;
  public projectRoles: ProjectRole[] = [];

  constructor(
    private _route: ActivatedRoute
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: {
      user: AdminFullUser,
      projectRoles: ProjectRole[]
    }) => {
      this.user = data.user;
      this.projectRoles = data.projectRoles;
    });
  }

  public getFullName() {
    return `${this.user.firstName} ${this.user.lastName}`;
  }
}
