import {Component, Inject} from '@angular/core';
import { MD_DIALOG_DATA, MdDialogRef } from '@angular/material';
import { ShootingDay } from "../../index";

@Component({
    selector: 'choose-shooting-day-dialog',
    templateUrl: "choose-shooting-day-dialog.component.html",
})

export class ChooseShootingDayDialog {

    shootingDays: ShootingDay[] = [];

    constructor(
        private _dialogRef: MdDialogRef<ChooseShootingDayDialog>,
        @Inject(MD_DIALOG_DATA) private data: ShootingDay[]
    ) { 
        this.shootingDays = data;
    }

    chooseShootingDay(shootingDay: ShootingDay){
        this._dialogRef.close(shootingDay);
    }
}