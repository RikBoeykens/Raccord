import { Component, Inject } from '@angular/core';
import { MD_DIALOG_DATA, MdDialogRef } from '@angular/material';
import { ShootingDayCrewUnit } from '../../model/shooting-day-crew-unit.model';

@Component({
    selector: 'choose-shooting-day-crew-unit-dialog',
    templateUrl: 'choose-shooting-day-crew-unit-dialog.component.html',
})

export class ChooseShootingDayCrewUnitDialogComponent {

    public shootingDays: ShootingDayCrewUnit[] = [];

    constructor(
        private _dialogRef: MdDialogRef<ChooseShootingDayCrewUnitDialogComponent>,
        @Inject(MD_DIALOG_DATA) private data: {shootingDays: ShootingDayCrewUnit[]}
    ) {
        this.shootingDays = data.shootingDays;
    }

    public chooseShootingDay(shootingDay: ShootingDayCrewUnit) {
        this._dialogRef.close(shootingDay);
    }
}