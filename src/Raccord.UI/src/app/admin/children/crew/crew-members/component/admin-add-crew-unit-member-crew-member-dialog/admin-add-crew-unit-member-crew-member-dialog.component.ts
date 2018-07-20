import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import {
  CreateCrewUnitMemberCrewMember
} from '../../model/create-crew-unit-member-crew-member.model';
import { CrewDepartment } from '../../../../../../shared/children/crew';

@Component({
  templateUrl: 'admin-add-crew-unit-member-crew-member-dialog.component.html',
})

export class AdminAddCrewUnitMemberCrewMemberDialogComponent {
  public crewMemberInfo: CreateCrewUnitMemberCrewMember = new CreateCrewUnitMemberCrewMember();
  public availableDepartments: CrewDepartment[];

  constructor(
    private _dialogRef: MatDialogRef<AdminAddCrewUnitMemberCrewMemberDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: {
      linkID: number,
      departments: CrewDepartment[]
    }
  ) {
    this.crewMemberInfo.linkID = data.linkID;
    this.availableDepartments = data.departments;
  }

  public submit() {
    this._dialogRef.close({ crewMemberInfo: this.crewMemberInfo });
  }
}
