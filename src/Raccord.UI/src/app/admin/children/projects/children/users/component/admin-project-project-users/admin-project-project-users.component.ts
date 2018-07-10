import { Component, Input } from '@angular/core';
import { MatDialog } from '@angular/material';
import {
  ProjectUserUser,
  ProjectRole,
  ProjectUser
} from '../../../../../../../shared/children/users';
import {
  AdminProjectsAddUserDialogComponent,
  CreateUser,
  AdminProjectsLinkUserDialogComponent
} from '../../../../../..';
import { LoadingWrapperService } from '../../../../../../../shared/service/loading-wrapper.service';
import { DialogService } from '../../../../../../../shared/service/dialog.service';
import { AdminUserHttpService } from '../../../../../users/service/admin-user-http.service';
import {
  AdminProjectUserHttpService
} from '../../../../../project-users/service/admin-project-user-http.service';

@Component({
  selector: 'admin-project-project-users',
  templateUrl: 'admin-project-project-users.component.html',
})
export class AdminProjectProjectUsersComponent {
  @Input() public projectUsers: ProjectUserUser[];
  @Input() public projectRoles: ProjectRole;
  @Input() public projectId: number;

  constructor(
    private _dialog: MatDialog,
    private _dialogService: DialogService,
    private _loadingWrapperService: LoadingWrapperService,
    private _adminUserHttpService: AdminUserHttpService,
    private _adminProjectUserHttpService: AdminProjectUserHttpService
  ) {}

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

  public showLinkUser() {
    const linkUserDialog = this._dialog.open(AdminProjectsLinkUserDialogComponent, {data:
    {
        projectRoles: this.projectRoles
    }});
    linkUserDialog.afterClosed().subscribe((returnedData: {userId: string, roleId: number}) => {
      if (returnedData) {
          this.linkUser(returnedData.userId, returnedData.roleId);
      }
    });
  }

  public showConfirmRemoveUser(projectUser: ProjectUserUser) {
    this._dialogService.confirm(
      `Are you sure you want to remove ${projectUser.user.firstName} ${projectUser.user.lastName}?`,
      () => this.removeProjectUser(projectUser.id)
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
        projectID: this.projectId,
        userID: userId,
        roleID: roleId
      })),
      () => this.getUsers()
    );
  }

  private getUsers() {
    this._loadingWrapperService.Load(
      this._adminProjectUserHttpService.getUsers(this.projectId),
      (users: ProjectUserUser[]) => this.projectUsers = users
    );
  }

  private removeProjectUser(id: number) {
    this._loadingWrapperService.Load(
      this._adminProjectUserHttpService.delete(id),
      () => this.getUsers()
    );
  }
}
