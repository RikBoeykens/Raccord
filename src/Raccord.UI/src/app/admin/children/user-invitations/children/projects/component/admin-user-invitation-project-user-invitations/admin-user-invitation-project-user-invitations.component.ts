import { Component, Input } from '@angular/core';
import { MatDialog } from '@angular/material';
import {
  ProjectRole
} from '../../../../../../../shared/children/users';
import {
  AdminAddProjectRoleDialogComponent,
  AdminChooseProjectRoleDialogComponent
} from '../../../../../..';
import { LoadingWrapperService } from '../../../../../../../shared/service/loading-wrapper.service';
import { DialogService } from '../../../../../../../shared/service/dialog.service';
import {
  AdminProjectUserInvitationHttpService
} from '../../../../../project-user-invitations/service/admin-project-user-invitation-http.service';
import {
  AdminProjectHttpService
} from '../../../../../projects/service/admin-project-http.service';
import { Project } from '../../../../../../../shared/children/projects';
import {
  ProjectUserInvitationProject,
  ProjectUserInvitation
} from '../../../../../../../shared/children/user-invitations';

@Component({
  selector: 'admin-user-invitation-project-user-invitations',
  templateUrl: 'admin-user-invitation-project-user-invitations.component.html',
})
export class AdminUserInvitationProjectUserInvitationsComponent {
  @Input() public projectUserInvitations: ProjectUserInvitationProject[];
  @Input() public projectRoles: ProjectRole;
  @Input() public userInvitationId: string;

  constructor(
    private _dialog: MatDialog,
    private _dialogService: DialogService,
    private _loadingWrapperService: LoadingWrapperService,
    private _adminProjectHttpService: AdminProjectHttpService,
    private _adminProjectUserInvitationHttpService: AdminProjectUserInvitationHttpService
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

  public showConfirmRemoveProject(projectUserInvitation: ProjectUserInvitationProject) {
    this._dialogService.confirm(
      `Are you sure you want to remove ${projectUserInvitation.project.title}?`,
      () => this.removeProjectUserInvitation(projectUserInvitation.id)
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
      this._adminProjectUserInvitationHttpService.add(new ProjectUserInvitation({
        id: 0,
        projectID: projectId,
        userInvitationID: this.userInvitationId,
        roleID: roleId
      })),
      () => this.getProjects()
    );
  }

  private getProjects() {
    this._loadingWrapperService.Load(
      this._adminProjectUserInvitationHttpService.getProjects(this.userInvitationId),
      (projects: ProjectUserInvitationProject[]) => this.projectUserInvitations = projects
    );
  }

  private removeProjectUserInvitation(id: number) {
    this._loadingWrapperService.Load(
      this._adminProjectUserInvitationHttpService.delete(id),
      () => this.getProjects()
    );
  }
}
