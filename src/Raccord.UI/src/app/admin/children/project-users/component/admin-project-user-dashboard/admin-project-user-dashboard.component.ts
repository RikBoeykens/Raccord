import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AdminFullProjectUser, AdminEditProjectRoleDialogComponent } from '../../../..';
import { RouteSettings } from '../../../../../shared';
import {
  LoadingWrapperService
} from '../../../../../shared/service/loading-wrapper.service';
import { MatDialog } from '../../../../../../../node_modules/@angular/material';
import { ProjectRole, ProjectUser } from '../../../../../shared/children/users';
import { AdminProjectUserHttpService } from '../../service/admin-project-user-http.service';

@Component({
  templateUrl: 'admin-project-user-dashboard.component.html',
})
export class AdminProjectUserDashboardComponent implements OnInit {
  public projectUser: AdminFullProjectUser;
  public projectRoles: ProjectRole[] = [];
  public backEntity: string;

  constructor(
    private _adminProjectUserHttpService: AdminProjectUserHttpService,
    private _route: ActivatedRoute,
    private _loadingWrapperService: LoadingWrapperService,
    private _dialog: MatDialog
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: {
      projectUser: AdminFullProjectUser,
      projectRoles: ProjectRole[]
    }) => {
      this.projectUser = data.projectUser;
      this.projectRoles = data.projectRoles;
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

  public showEditProjectUser() {
    const editProjectDialog = this._dialog.open(AdminEditProjectRoleDialogComponent, {data:
    {
        chosenRoleId: this.projectUser.projectRole.id,
        title: 'Edit Project User',
        projectRoles: this.projectRoles
    }});
    editProjectDialog.afterClosed().subscribe((returnedInfo: {roleId?: number}) => {
      if (returnedInfo) {
          this.postProjectUser(returnedInfo.roleId);
      }
    });
  }

  private postProjectUser(roleId: number) {
    const projectUser = new ProjectUser({
      id: this.projectUser.id,
      projectID: this.projectUser.project.id,
      userID: this.projectUser.user.id,
      roleID: roleId
    });
    this._loadingWrapperService.Load(
      this._adminProjectUserHttpService.post(projectUser),
      () => {
        this.getProjectUser();
      }
    );
  }

  private getProjectUser() {
    this._loadingWrapperService.Load(
      this._adminProjectUserHttpService.get(this.projectUser.id),
      (data: AdminFullProjectUser) => { this.projectUser = data; }
    );
  }
}
