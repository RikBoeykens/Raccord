import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import {
  SearchResult
} from '../../../../../shared/children/search';
import { EntityType } from '../../../../../shared';

@Component({
  templateUrl: 'admin-choose-cast-member-dialog.component.html',
})

export class AdminChooseCastMemberDialogComponent {
  public selectedCastMember: SearchResult = new SearchResult();
  public castMemberEntityType: EntityType = EntityType.castMember;
  public projectId: number;

  constructor(
    private _dialogRef: MatDialogRef<AdminChooseCastMemberDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: {
      projectId: number
    }
  ) {
    this.projectId = data.projectId;
  }

  public submit() {
    this._dialogRef.close({castMemberId: this.selectedCastMember.id});
  }

  public onSelect(searchResult: SearchResult) {
    this.selectedCastMember = searchResult;
  }

  public removeSelectedCastMember() {
    this.selectedCastMember = new SearchResult();
  }
}
