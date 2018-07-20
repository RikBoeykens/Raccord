import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { CrewUnitSummary } from '../../../../../../shared/children/crew';

@Component({
  templateUrl: 'admin-choose-crew-unit-dialog.component.html',
})

export class AdminChooseCrewUnitDialogComponent {
  public title: string;
  public crewUnits: CrewUnitSummary[];

  constructor(
    private _dialogRef: MatDialogRef<AdminChooseCrewUnitDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: {
      title: string,
      crewUnits: CrewUnitSummary[]
    }
  ) {
    this.title = data.title;
    this.crewUnits = data.crewUnits;
  }

  public onClick(crewUnit: CrewUnitSummary) {
    this._dialogRef.close({
      crewUnitId: crewUnit.id
    });
  }
}
