import { Component, Inject } from '@angular/core';
import { MD_DIALOG_DATA, MdDialogRef } from '@angular/material';
import { UserInvitation } from '../../../../invitations/model/user-invitation.model';

@Component({
    selector: 'admin-add-user-invitation-dialog',
    templateUrl: 'admin-add-user-invitation-dialog.component.html',
})

export class AdminAddUserInvitationDialogComponent {

    public invitation: UserInvitation;

    constructor(
        private _dialogRef: MdDialogRef<AdminAddUserInvitationDialogComponent>,
        @Inject(MD_DIALOG_DATA) private data: {
            invitation: UserInvitation
        }
    ) {
        this.invitation = data.invitation;
    }

    public submit() {
        this._dialogRef.close(this.invitation);
    }
}
