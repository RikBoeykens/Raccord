import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AdminUserHttpService } from '../../service/admin-user-http.service';
import { UserSummary } from '../../model/user-summary.model';
import { LoadingService } from '../../../../loading/service/loading.service';
import { DialogService } from '../../../../shared/service/dialog.service';
import { Image } from '../../children/images/model/image.model';
import { LoadingWrapperService } from '../../../../shared/service/loading-wrapper.service';
import { UserInvitationSummary } from '../../../../invitations/model/user-invitation-summary.model';
import { AdminUserInvitationHttpService } from '../../..';
import { MdDialog } from '@angular/material';
import { AdminAddUserInvitationDialogComponent } from
    '../admin-add-user-invitation-dialog/admin-add-user-invitation-dialog.component';
import { UserInvitation } from '../../../../invitations/model/user-invitation.model';
import { UserInvitationResult } from '../../../../invitations/model/user-invitation-result.model';

@Component({
    templateUrl: 'admin-user-invitations-list.component.html',
})
export class AdminUserInvitationsListComponent implements OnInit {

    public invitations: UserInvitationSummary[] = [];

    constructor(
        private _adminUserInvitationHttpService: AdminUserInvitationHttpService,
        private _loadingWrapperService: LoadingWrapperService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router,
        private _dialog: MdDialog
    ) {
    }

    public ngOnInit() {
        this._route.data.subscribe((data: { invitations: UserInvitationSummary[] }) => {
            this.invitations = data.invitations;
        });
    }

    public getInvitations() {
        this._loadingWrapperService.Load(
            this._adminUserInvitationHttpService.getAll(),
            (data) => this.invitations = data
        );
    }

    public remove(invitation: UserInvitationSummary) {
        if (this._dialogService.confirm(
            `Are you sure you want to remove invitation for ${this.getFullName(invitation)}`)) {
            this._loadingWrapperService.Load(
                this._adminUserInvitationHttpService.delete(invitation.id),
                () => {
                    this._dialogService.success('The invitation was successfully removed');
                    this.getInvitations();
                }
            );
        }

    }

    public getFullName(invitation: UserInvitationSummary) {
        return `${invitation.firstName} ${invitation.lastName}`;
    }

    public showAddInvitation() {
        let addInvitationDialog = this._dialog.open(AdminAddUserInvitationDialogComponent, {data:
        {
            invitation: new UserInvitation()
        }});
        addInvitationDialog.afterClosed().subscribe((invitation: UserInvitation) => {
            if (invitation) {
                this.addInvitation(invitation);
            }
        });
    }

    private addInvitation(invitation: UserInvitation) {
        this._loadingWrapperService.Load(
            this._adminUserInvitationHttpService.add(invitation),
            (result: UserInvitationResult) => 
                this._router.navigate(['admin', 'invitations', result.id])
        );
    }
}
