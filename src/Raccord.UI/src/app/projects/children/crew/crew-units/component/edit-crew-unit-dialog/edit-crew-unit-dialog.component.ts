import { Component, Inject } from '@angular/core';
import { MD_DIALOG_DATA, MdDialogRef } from '@angular/material';
import { CrewUnit } from '../../model/crew-unit.model';

@Component({
    selector: 'edit-crew-unit-dialog',
    templateUrl: 'edit-crew-unit-dialog.component.html',
})

export class EditCrewUnitDialogComponent {

    public crewUnit: CrewUnit;

    constructor(
        private _dialogRef: MdDialogRef<EditCrewUnitDialogComponent>,
        @Inject(MD_DIALOG_DATA) private data: {
            crewUnit: CrewUnit,
        }
    ) {
        this.crewUnit = data.crewUnit;
    }

    public submit() {
        this._dialogRef.close(this.crewUnit);
    }
}
