import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ProjectRole } from '../../../../../../../shared/children/users';
import {
  SearchResult
} from '../../../../../../../shared/children/search';
import { EntityType } from '../../../../../../../shared';

@Component({
  templateUrl: 'admin-projects-link-user-dialog.component.html',
})

export class AdminProjectsLinkUserDialogComponent {
  public selectedUser: SearchResult = new SearchResult();
  public chosenRoleId: number;
  public availableRoles: ProjectRole[];
  public userEntityType: EntityType = EntityType.user;

  constructor(
    private _dialogRef: MatDialogRef<AdminProjectsLinkUserDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: {
      projectRoles: ProjectRole[]
    }
  ) {
    this.availableRoles = data.projectRoles;
  }

  public submit() {
    this._dialogRef.close({userId: this.selectedUser.id, roleId: this.chosenRoleId});
  }

  public onSelect(searchResult: SearchResult) {
    this.selectedUser = searchResult;
  }

  public removeSelectedUser() {
    this.selectedUser = new SearchResult();
  }
}
