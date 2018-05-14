import { Component, Inject } from '@angular/core';
import { MD_DIALOG_DATA, MdDialogRef } from '@angular/material';
import { BreakdownType } from '../../model/breakdown-type.model';

@Component({
    selector: 'edit-breakdown-type-dialog',
    templateUrl: 'edit-breakdown-type-dialog.component.html',
})

export class EditBreakdownTypeDialogComponent {

    public breakdownType: BreakdownType;

    constructor(
        private _dialogRef: MdDialogRef<EditBreakdownTypeDialogComponent>,
        @Inject(MD_DIALOG_DATA) private data: BreakdownType
    ) {
        this.breakdownType = data;
    }

    public submit() {
        this._dialogRef.close(this.breakdownType);
    }
}