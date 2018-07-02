import { Component, Inject } from '@angular/core';
import { CreateUser } from '../../../..';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ProjectRole } from '../../../../../shared/children/users';

@Component({
  templateUrl: 'admin-projects-add-user-dialog.component.html',
})

export class AdminProjectsAddUserDialogComponent {
  public user: CreateUser;
  public chosenRoleId: number;
  public availableRoles: ProjectRole[];

  constructor(
    private _dialogRef: MatDialogRef<AdminProjectsAddUserDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: {
      projectRoles: ProjectRole[]
    }
  ) {
    this.user = new CreateUser();
    this.availableRoles = data.projectRoles;
  }

  public submit() {
    this._dialogRef.close({user: this.user, roleId: this.chosenRoleId});
  }
}
