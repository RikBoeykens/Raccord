import { AdminFullProject } from '../../model/admin-full-project.model';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Project } from '../../../../../shared/children/projects';
import { MatDialog } from '@angular/material';
import { AdminEditProjectDialogComponent } from '../../../..';
import { AdminProjectHttpService } from '../../service/admin-project-http.service';
import { LoadingWrapperService, DialogService } from '../../../../../shared';
import { ProjectRole, ProjectUser, ProjectUserUser } from '../../../../../shared/children/users';
// tslint:disable-next-line:max-line-length
import { AdminProjectsAddUserDialogComponent } from '../admin-projects-add-user-dialog/admin-projects-add-user-dialog.component';
import { CreateUser } from '../../../users/model/create-user.model';
import { AdminUserHttpService } from '../../../users/service/admin-user-http.service';
// tslint:disable-next-line:max-line-length
import { AdminProjectUserHttpService } from '../../../project-users/service/admin-project-user-http.service';

@Component({
  templateUrl: 'admin-project-dashboard.component.html',
})
export class AdminProjectDashboardComponent implements OnInit {
  public project: AdminFullProject;
  public projectRoles: ProjectRole[] = [];

  constructor(
    private _adminProjectHttpService: AdminProjectHttpService,
    private _adminUserHttpService: AdminUserHttpService,
    private _adminProjectUserHttpService: AdminProjectUserHttpService,
    private _loadingWrapperService: LoadingWrapperService,
    private _dialogService: DialogService,
    private _route: ActivatedRoute,
    private _dialog: MatDialog
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: {
      project: AdminFullProject,
      projectRoles: ProjectRole[]
    }) => {
      this.project = data.project;
      this.projectRoles = data.projectRoles;
    });
  }

  public showEditProject() {
    const editProjectDialog = this._dialog.open(AdminEditProjectDialogComponent, {data:
    {
        project: new Project(this.project),
        dialogTitle: 'Edit Project'
    }});
    editProjectDialog.afterClosed().subscribe((returnedProject: Project) => {
      if (returnedProject) {
          this.postProject(returnedProject);
      }
    });
  }

  public showAddUser() {
    const addUserDialog = this._dialog.open(AdminProjectsAddUserDialogComponent, {data:
    {
        projectRoles: this.projectRoles
    }});
    addUserDialog.afterClosed().subscribe((returnedData: {user: CreateUser, roleId: number}) => {
      if (returnedData) {
          this.createUser(returnedData.user, returnedData.roleId);
      }
    });
  }

  public showConfirmRemoveUser(projectUser: ProjectUserUser) {
    this._dialogService.confirm(
      `Are you sure you want to remove ${projectUser.user.firstName} ${projectUser.user.lastName}?`,
      () => this.removeProjectUser(projectUser.id)
    );
  }

  private postProject(project: Project) {
    this._loadingWrapperService.Load(
      this._adminProjectHttpService.post(project),
      () => {
        this.project.title = project.title;
      }
    );
  }

  private createUser(user: CreateUser, roleId?: number) {
    this._loadingWrapperService.Load(
      this._adminUserHttpService.add(user),
      (userId: string) => this.linkUser(userId, roleId)
    );
  }

  private linkUser(userId: string, roleId?: number) {
    this._loadingWrapperService.Load(
      this._adminProjectUserHttpService.post(new ProjectUser({
        id: 0,
        projectID: this.project.id,
        userID: userId,
        roleID: roleId
      })),
      () => this.getUsers()
    );
  }

  private getUsers() {
    this._loadingWrapperService.Load(
      this._adminProjectUserHttpService.getUsers(this.project.id),
      (users: ProjectUserUser[]) => this.project.users = users
    );
  }

  private removeProjectUser(id: number) {
    this._loadingWrapperService.Load(
      this._adminProjectUserHttpService.delete(id),
      () => this.getUsers()
    );
  }
}
