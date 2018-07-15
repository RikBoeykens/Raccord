import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatDialog } from '@angular/material';
import { AdminUserInvitationSummary, AdminAddUserInvitationDialogComponent } from '../../../..';
import { AdminUserInvitationHttpService } from '../../service/admin-user-invitation-http.service';
import { LoadingWrapperService } from '../../../../../shared/service/loading-wrapper.service';
import { UserInvitation } from '../../../../../shared/children/user-invitations';
import { RouteSettings } from '../../../../../shared';

@Component({
  templateUrl: 'admin-user-invitations-list.component.html',
})
export class AdminUserInvitationsListComponent implements OnInit {
  public userInvitations: AdminUserInvitationSummary[] = [];

  constructor(
    private _adminUserInvitationHttpService: AdminUserInvitationHttpService,
    private _loadingWrapperService: LoadingWrapperService,
    private _dialog: MatDialog,
    private _route: ActivatedRoute
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: { userInvitations: AdminUserInvitationSummary[] }) => {
      this.setUserInvitations(data.userInvitations);
    });
  }

  public setUserInvitations(userInvitations: AdminUserInvitationSummary[]) {
    this.userInvitations = userInvitations;
  }

  public getUserInvitations() {
    this._loadingWrapperService.Load(
      this._adminUserInvitationHttpService.getAll(),
      (data) => this.setUserInvitations(data)
    );
  }

  public showAddUserInvitation() {
    this.showAddUserInvitationDialog();
  }

  public getBackLink() {
    return `/${RouteSettings.ADMIN}`;
  }

  private showAddUserInvitationDialog() {
    const addUserDialog = this._dialog.open(AdminAddUserInvitationDialogComponent);
    addUserDialog.afterClosed().subscribe((returnedUserInvitation: UserInvitation) => {
      if (returnedUserInvitation) {
          this.addUserInvitation(returnedUserInvitation);
      }
    });
  }

  private addUserInvitation(userInvitation: UserInvitation) {
    this._loadingWrapperService.Load(
      this._adminUserInvitationHttpService.add(userInvitation),
      () => {
        this.getUserInvitations();
      }
    );
  }
}
