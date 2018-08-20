import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Project } from '../../../../../shared/children/projects';

@Component({
  selector: 'admin-edit-project-dialog',
  templateUrl: 'admin-edit-project-dialog.component.html',
})

export class AdminEditProjectDialogComponent {
  public project: Project;
  public dialogTitle: string;

  constructor(
    private _dialogRef: MatDialogRef<AdminEditProjectDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: {
      project: Project,
      dialogTitle: string
    }
  ) {
    this.project = data.project;
    this.dialogTitle = data.dialogTitle;
  }

  public submit() {
    this._dialogRef.close(this.project);
  }
}
