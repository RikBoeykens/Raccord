import { Component, Inject } from '@angular/core';
import { MD_DIALOG_DATA, MdDialogRef } from '@angular/material';
import { CastMemberSummary } from
    '../../../../projects/children/cast/model/cast-member-summary.model';

@Component({
    selector: 'admin-add-cast-dialog',
    templateUrl: 'admin-add-cast-dialog.component.html',
})

export class AdminAddCastDialogComponent {

    public castMembers: CastMemberSummary[];

    constructor(
        private _dialogRef: MdDialogRef<AdminAddCastDialogComponent>,
        @Inject(MD_DIALOG_DATA) private data: {
            castMembers: CastMemberSummary[]
        }
    ) {
        this.castMembers = data.castMembers;
    }

    public chooseCastMember(character: CastMemberSummary) {
        this._dialogRef.close(character);
    }
}
