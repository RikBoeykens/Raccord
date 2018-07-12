import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ProjectRole } from '../../../../../shared/children/users';
import {
  SearchResult
} from '../../../../../shared/children/search';
import { EntityType } from '../../../../../shared';

@Component({
  templateUrl: 'admin-choose-project-role-dialog.component.html',
})

export class AdminChooseProjectRoleDialogComponent {
  public selectedProject: SearchResult = new SearchResult();
  public chosenRoleId: number;
  public availableRoles: ProjectRole[];
  public projectEntityType: EntityType = EntityType.project;

  constructor(
    private _dialogRef: MatDialogRef<AdminChooseProjectRoleDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: {
      projectRoles: ProjectRole[]
    }
  ) {
    this.availableRoles = data.projectRoles;
  }

  public submit() {
    this._dialogRef.close({projectId: this.selectedProject.id, roleId: this.chosenRoleId});
  }

  public onSelect(searchResult: SearchResult) {
    this.selectedProject = searchResult;
  }

  public removeSelectedProject() {
    this.selectedProject = new SearchResult();
  }
}
