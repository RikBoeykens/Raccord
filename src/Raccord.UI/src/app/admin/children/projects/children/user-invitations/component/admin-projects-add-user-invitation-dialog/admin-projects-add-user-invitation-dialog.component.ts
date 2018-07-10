import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ProjectRole } from '../../../../../../../shared/children/users';
import { UserInvitation } from '../../../../../../../shared/children/user-invitations';

@Component({
  templateUrl: 'admin-projects-add-user-invitation-dialog.component.html',
})

export class AdminProjectsAddUserInvitationDialogComponent {
  public userInvitation: UserInvitation;
  public chosenRoleId: number;
  public availableRoles: ProjectRole[];

  constructor(
    private _dialogRef: MatDialogRef<AdminProjectsAddUserInvitationDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: {
      projectRoles: ProjectRole[]
    }
  ) {
    this.userInvitation = new UserInvitation();
    this.availableRoles = data.projectRoles;
  }

  public submit() {
    this._dialogRef.close({userInvitation: this.userInvitation, roleId: this.chosenRoleId});
  }
}
