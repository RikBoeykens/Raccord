import { Component, Inject } from '@angular/core';
import { MD_DIALOG_DATA, MdDialogRef } from '@angular/material';
import { CrewUnitSummary } from '../../model/crew-unit-summary.model';

@Component({
    selector: 'choose-crew-unit-dialog',
    templateUrl: 'choose-crew-unit-dialog.component.html',
})

export class ChooseCrewUnitDialogComponent {

    public crewUnits: CrewUnitSummary[] = [];

    constructor(
        private _dialogRef: MdDialogRef<ChooseCrewUnitDialogComponent>,
        @Inject(MD_DIALOG_DATA) private data: {crewUnits: CrewUnitSummary[]}
    ) {
        this.crewUnits = data.crewUnits;
    }

    public chooseCrewUnit(crewUnit: CrewUnitSummary) {
        this._dialogRef.close(crewUnit);
    }
}
