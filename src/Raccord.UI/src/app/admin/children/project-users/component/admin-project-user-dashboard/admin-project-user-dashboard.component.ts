import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AdminFullProjectUser } from '../../../..';
import { RouteSettings, EntityType } from '../../../../../shared';

@Component({
  templateUrl: 'admin-project-user-dashboard.component.html',
})
export class AdminProjectUserDashboardComponent implements OnInit {
  public projectUser: AdminFullProjectUser;
  public backEntity: string;

  constructor(
    private _route: ActivatedRoute
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: {
      projectUser: AdminFullProjectUser
    }) => {
      this.projectUser = data.projectUser;
    });
    this.backEntity = this._route.snapshot.queryParams['src'] || '';
  }

  public getFullName() {
    return `${this.projectUser.user.firstName} ${this.projectUser.user.lastName}`;
  }

  public getBackLink() {
    if (this.backEntity === 'project') {
      return this.getProjectLink();
    }
    return this.getUserLink();
  }

  public getUserLink() {
    return `/${RouteSettings.ADMIN}/${RouteSettings.USERS}/${this.projectUser.user.id}`;
  }

  public getProjectLink() {
    return `/${RouteSettings.ADMIN}/${RouteSettings.PROJECTS}/${this.projectUser.project.id}`;
  }
}
