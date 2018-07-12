import { Component, Input } from '@angular/core';
import { MatDialog } from '@angular/material';
import {
  ProjectRole,
  ProjectUser,
  ProjectUserProject
} from '../../../../../../../shared/children/users';
import {
  AdminAddProjectRoleDialogComponent,
  AdminChooseProjectRoleDialogComponent
} from '../../../../../..';
import { LoadingWrapperService } from '../../../../../../../shared/service/loading-wrapper.service';
import { DialogService } from '../../../../../../../shared/service/dialog.service';
import {
  AdminProjectUserHttpService
} from '../../../../../project-users/service/admin-project-user-http.service';
import {
  AdminProjectHttpService
} from '../../../../../projects/service/admin-project-http.service';
import { Project } from '../../../../../../../shared/children/projects';

@Component({
  selector: 'admin-user-project-users',
  templateUrl: 'admin-user-project-users.component.html',
})
export class AdminUserProjectUsersComponent {
  @Input() public projectUsers: ProjectUserProject[];
  @Input() public projectRoles: ProjectRole;
  @Input() public userId: string;

  constructor(
    private _dialog: MatDialog,
    private _dialogService: DialogService,
    private _loadingWrapperService: LoadingWrapperService,
    private _adminProjectHttpService: AdminProjectHttpService,
    private _adminProjectUserHttpService: AdminProjectUserHttpService
  ) {}

  public showAddProject() {
    const addProjectDialog = this._dialog.open(AdminAddProjectRoleDialogComponent, {data:
    {
        projectRoles: this.projectRoles
    }});
    addProjectDialog.afterClosed().subscribe((returnedData: {project: Project, roleId: number}) => {
      if (returnedData) {
          this.createProject(returnedData.project, returnedData.roleId);
      }
    });
  }

  public showLinkProject() {
    const linkProjectDialog = this._dialog.open(AdminChooseProjectRoleDialogComponent, {data:
    {
        projectRoles: this.projectRoles
    }});
    linkProjectDialog.afterClosed().subscribe((returnedData: {
      projectId: number,
      roleId: number
    }) => {
      if (returnedData) {
          this.linkProject(returnedData.projectId, returnedData.roleId);
      }
    });
  }

  public showConfirmRemoveProject(projectUser: ProjectUserProject) {
    this._dialogService.confirm(
      `Are you sure you want to remove ${projectUser.project.title}?`,
      () => this.removeProjectUser(projectUser.id)
    );
  }

  private createProject(project: Project, roleId?: number) {
    this._loadingWrapperService.Load(
      this._adminProjectHttpService.post(project),
      (projectId: number) => this.linkProject(projectId, roleId)
    );
  }

  private linkProject(projectId: number, roleId?: number) {
    this._loadingWrapperService.Load(
      this._adminProjectUserHttpService.post(new ProjectUser({
        id: 0,
        projectID: projectId,
        userID: this.userId,
        roleID: roleId
      })),
      () => this.getProjects()
    );
  }

  private getProjects() {
    this._loadingWrapperService.Load(
      this._adminProjectUserHttpService.getProjects(this.userId),
      (projects: ProjectUserProject[]) => this.projectUsers = projects
    );
  }

  private removeProjectUser(id: number) {
    this._loadingWrapperService.Load(
      this._adminProjectUserHttpService.delete(id),
      () => this.getProjects()
    );
  }
}
