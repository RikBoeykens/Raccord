import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AdminEditProjectRoleDialogComponent } from '../../../..';
import { RouteSettings } from '../../../../../shared';
import {
  LoadingWrapperService
} from '../../../../../shared/service/loading-wrapper.service';
import { MatDialog } from '../../../../../../../node_modules/@angular/material';
import { ProjectRole } from '../../../../../shared/children/users';
import {
  AdminProjectUserInvitationHttpService
} from '../../service/admin-project-user-invitation-http.service';
import {
  AdminFullProjectUserInvitation
} from '../../model/admin-full-project-user-invitation.model';
import { ProjectUserInvitation } from '../../../../../shared/children/user-invitations';

@Component({
  templateUrl: 'admin-project-user-invitation-dashboard.component.html',
})
export class AdminProjectUserInvitationDashboardComponent implements OnInit {
  public projectUserInvitation: AdminFullProjectUserInvitation;
  public projectRoles: ProjectRole[] = [];
  public backEntity: string;

  constructor(
    private _adminProjectUserInvitationHttpService: AdminProjectUserInvitationHttpService,
    private _route: ActivatedRoute,
    private _loadingWrapperService: LoadingWrapperService,
    private _dialog: MatDialog
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: {
      projectUserInvitation: AdminFullProjectUserInvitation,
      projectRoles: ProjectRole[]
    }) => {
      this.projectUserInvitation = data.projectUserInvitation;
      this.projectRoles = data.projectRoles;
    });
    this.backEntity = this._route.snapshot.queryParams['src'] || '';
  }

  public getFullName() {
    // tslint:disable-next-line:max-line-length
    return `${this.projectUserInvitation.userInvitation.firstName} ${this.projectUserInvitation.userInvitation.lastName}`;
  }

  public getBackLink() {
    if (this.backEntity === 'project') {
      return this.getProjectLink();
    }
    return this.getUserInvitationLink();
  }

  public getUserInvitationLink() {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.ADMIN}/${RouteSettings.INVITATIONS}/${this.projectUserInvitation.userInvitation.id}`;
  }

  public getProjectLink() {
    // tslint:disable-next-line:max-line-length
    return `/${RouteSettings.ADMIN}/${RouteSettings.PROJECTS}/${this.projectUserInvitation.project.id}`;
  }

  public showEditProjectUserInvitation() {
    const editProjectDialog = this._dialog.open(AdminEditProjectRoleDialogComponent, {data:
    {
        chosenRoleId: this.projectUserInvitation.projectRole.id,
        title: 'Edit Project Invitation',
        projectRoles: this.projectRoles
    }});
    editProjectDialog.afterClosed().subscribe((returnedInfo: {roleId?: number}) => {
      if (returnedInfo) {
          this.postProjectUserInvitation(returnedInfo.roleId);
      }
    });
  }

  private postProjectUserInvitation(roleId: number) {
    const projectUser = new ProjectUserInvitation({
      id: this.projectUserInvitation.id,
      projectID: this.projectUserInvitation.project.id,
      userInvitationID: this.projectUserInvitation.userInvitation.id,
      roleID: roleId
    });
    this._loadingWrapperService.Load(
      this._adminProjectUserInvitationHttpService.update(projectUser),
      () => {
        this.getProjectUserInvitation();
      }
    );
  }

  private getProjectUserInvitation() {
    this._loadingWrapperService.Load(
      this._adminProjectUserInvitationHttpService.get(this.projectUserInvitation.id),
      (data: AdminFullProjectUserInvitation) => { this.projectUserInvitation = data; }
    );
  }
}
