import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ProjectRole } from '../../../../../shared/children/users';

@Component({
  templateUrl: 'admin-edit-project-role-dialog.component.html',
})

export class AdminEditProjectRoleDialogComponent {
  public title: string;
  public chosenRoleId?: number;
  public availableRoles: ProjectRole[];

  constructor(
    private _dialogRef: MatDialogRef<AdminEditProjectRoleDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: {
      title: string,
      chosenRoleId?: number
      projectRoles: ProjectRole[]
    }
  ) {
    this.title = data.title;
    this.chosenRoleId = data.chosenRoleId;
    this.availableRoles = data.projectRoles;
  }

  public submit() {
    this._dialogRef.close({roleId: this.chosenRoleId});
  }
}
