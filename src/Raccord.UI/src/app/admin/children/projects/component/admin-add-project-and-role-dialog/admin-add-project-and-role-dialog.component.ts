import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ProjectRole } from '../../../../../shared/children/users';
import { Project } from '../../../../../shared/children/projects';

@Component({
  templateUrl: 'admin-add-project-and-role-dialog.component.html',
})

export class AdminAddProjectAndRoleDialogComponent {
  public project: Project = new Project();
  public chosenRoleId: number;
  public availableRoles: ProjectRole[];

  constructor(
    private _dialogRef: MatDialogRef<AdminAddProjectAndRoleDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: {
      projectRoles: ProjectRole[]
    }
  ) {
    this.availableRoles = data.projectRoles;
  }

  public submit() {
    this._dialogRef.close({project: this.project, roleId: this.chosenRoleId});
  }
}
