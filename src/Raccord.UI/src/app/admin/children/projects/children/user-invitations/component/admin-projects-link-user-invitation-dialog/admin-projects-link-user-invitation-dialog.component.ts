import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ProjectRole } from '../../../../../../../shared/children/users';
import {
  SearchResult
} from '../../../../../../../shared/children/search';
import { EntityType } from '../../../../../../../shared';

@Component({
  templateUrl: 'admin-projects-link-user-invitation-dialog.component.html',
})

export class AdminProjectsLinkUserInvitationDialogComponent {
  public selectedUserInvitation: SearchResult = new SearchResult();
  public chosenRoleId: number;
  public availableRoles: ProjectRole[];
  public userInvitationEntityType: EntityType = EntityType.userInvitation;

  constructor(
    private _dialogRef: MatDialogRef<AdminProjectsLinkUserInvitationDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: {
      projectRoles: ProjectRole[]
    }
  ) {
    this.availableRoles = data.projectRoles;
  }

  public submit() {
    this._dialogRef.close({
      userInvitationId: this.selectedUserInvitation.id,
      roleId: this.chosenRoleId
    });
  }

  public onSelect(searchResult: SearchResult) {
    this.selectedUserInvitation = searchResult;
  }

  public removeSelectedUserInvitation() {
    this.selectedUserInvitation = new SearchResult();
  }
}
