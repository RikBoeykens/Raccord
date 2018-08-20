import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { UserInvitation } from '../../../../../shared/children/user-invitations';

@Component({
  selector: 'admin-add-user-invitation-dialog',
  templateUrl: 'admin-add-user-invitation-dialog.component.html',
})

export class AdminAddUserInvitationDialogComponent {
  public userInvitation: UserInvitation = new UserInvitation();

  constructor(
    private _dialogRef: MatDialogRef<AdminAddUserInvitationDialogComponent>
  ) {
  }

  public submit() {
    this._dialogRef.close(this.userInvitation);
  }
}
