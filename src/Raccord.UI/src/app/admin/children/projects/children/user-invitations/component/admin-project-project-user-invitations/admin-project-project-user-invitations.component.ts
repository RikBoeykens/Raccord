import { Component, Input } from '@angular/core';
import { MatDialog } from '@angular/material';
import {
  ProjectRole
} from '../../../../../../../shared/children/users';
import {
  AdminProjectsAddUserInvitationDialogComponent,
  AdminProjectsLinkUserInvitationDialogComponent,
  AdminEditProjectRoleDialogComponent
} from '../../../../../..';
import {
  AdminUserInvitationHttpService
} from '../../../../../user-invitations/service/admin-user-invitation-http.service';
import {
  AdminProjectUserInvitationHttpService
} from '../../../../../project-user-invitations/service/admin-project-user-invitation-http.service';
import { LoadingWrapperService } from '../../../../../../../shared/service/loading-wrapper.service';
import { DialogService } from '../../../../../../../shared/service/dialog.service';
import {
  ProjectUserInvitationUserInvitation,
  UserInvitation,
  ProjectUserInvitation,
  UserInvitationResult
} from '../../../../../../../shared/children/user-invitations';

@Component({
  selector: 'admin-project-project-user-invitations',
  templateUrl: 'admin-project-project-user-invitations.component.html',
})
export class AdminProjectProjectUserInvitationsComponent {
  @Input() public projectUserInvitations: ProjectUserInvitationUserInvitation[];
  @Input() public projectRoles: ProjectRole;
  @Input() public projectId: number;

  constructor(
    private _dialog: MatDialog,
    private _dialogService: DialogService,
    private _loadingWrapperService: LoadingWrapperService,
    private _adminUserInvitationHttpService: AdminUserInvitationHttpService,
    private _adminProjectUserInvitationHttpService: AdminProjectUserInvitationHttpService
  ) {}

  public showAddUserInvitation() {
    const addUserInvitationDialog = this._dialog.open(
      AdminProjectsAddUserInvitationDialogComponent,
      {data:
        {
            projectRoles: this.projectRoles
        }}
    );
    addUserInvitationDialog.afterClosed().subscribe((returnedData: {
      userInvitation: UserInvitation,
      roleId: number
    }) => {
      if (returnedData) {
          this.createUserInvitation(returnedData.userInvitation, returnedData.roleId);
      }
    });
  }

  public showLinkUserInvitation() {
    const linkUserInvitationDialog = this._dialog.open(
      AdminProjectsLinkUserInvitationDialogComponent,
      {data:
        {
            projectRoles: this.projectRoles
        }}
    );
    linkUserInvitationDialog.afterClosed().subscribe((returnedData: {
      userInvitationId: string,
      roleId: number
    }) => {
      if (returnedData) {
          this.linkUserInvitation(returnedData.userInvitationId, returnedData.roleId);
      }
    });
  }

  public showConfirmRemoveUserInvitation(
    projectUserInvitation: ProjectUserInvitationUserInvitation
  ) {
    this._dialogService.confirm(
      // tslint:disable-next-line:max-line-length
      `Are you sure you want to remove ${projectUserInvitation.userInvitation.firstName} ${projectUserInvitation.userInvitation.lastName}?`,
      () => this.removeProjectUserInvitation(projectUserInvitation.id)
    );
  }

  public showEditUserInvitation(projectUserInvitation: ProjectUserInvitationUserInvitation) {
    const editProjectDialog = this._dialog.open(AdminEditProjectRoleDialogComponent, {data:
    {
        chosenRoleId: projectUserInvitation.projectRole.id,
        title: 'Edit Project Invitation',
        projectRoles: this.projectRoles
    }});
    editProjectDialog.afterClosed().subscribe((returnedInfo: {roleId?: number}) => {
      if (returnedInfo) {
        const editProjectUserInvitation = new ProjectUserInvitation({
          id: projectUserInvitation.id,
          projectID: this.projectId,
          userInvitationID: projectUserInvitation.userInvitation.id,
          roleID: returnedInfo.roleId
        });
        this.postProjectUserInvitation(editProjectUserInvitation);
      }
    });
  }

  private postProjectUserInvitation(projectUserInvitation: ProjectUserInvitation) {

    this._loadingWrapperService.Load(
      this._adminProjectUserInvitationHttpService.update(projectUserInvitation),
      () => {
        this.getUserInvitations();
      }
    );
  }

  private createUserInvitation(userInvitation: UserInvitation, roleId?: number) {
    this._loadingWrapperService.Load(
      this._adminUserInvitationHttpService.add(userInvitation),
      (userInvitationResult: UserInvitationResult) =>
        this.linkUserInvitation(userInvitationResult.id, roleId)
    );
  }

  private linkUserInvitation(userInvitationId: string, roleId?: number) {
    this._loadingWrapperService.Load(
      this._adminProjectUserInvitationHttpService.add(new ProjectUserInvitation({
        id: 0,
        projectID: this.projectId,
        userInvitationID: userInvitationId,
        roleID: roleId
      })),
      () => this.getUserInvitations()
    );
  }

  private getUserInvitations() {
    this._loadingWrapperService.Load(
      this._adminProjectUserInvitationHttpService.getUserInvitations(this.projectId),
      (userInvitations: ProjectUserInvitationUserInvitation[]) =>
        this.projectUserInvitations = userInvitations
    );
  }

  private removeProjectUserInvitation(id: number) {
    this._loadingWrapperService.Load(
      this._adminProjectUserInvitationHttpService.delete(id),
      () => this.getUserInvitations()
    );
  }
}
