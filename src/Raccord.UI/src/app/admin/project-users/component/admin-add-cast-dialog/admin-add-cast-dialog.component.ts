import { Component, Inject } from '@angular/core';
import { MD_DIALOG_DATA, MdDialogRef } from '@angular/material';
import { CastMemberSummary } from
    '../../../../projects/children/cast/model/cast-member-summary.model';
import { CastMember } from '../../../../projects/children/cast/model/cast-member.model';

@Component({
    selector: 'admin-add-cast-dialog',
    templateUrl: 'admin-add-cast-dialog.component.html',
})

export class AdminAddCastDialogComponent {
    public castMember: CastMember;

    constructor(
        private _dialogRef: MdDialogRef<AdminAddCastDialogComponent>,
        @Inject(MD_DIALOG_DATA) private data: {
            castMember: CastMember,
        }
    ) {
        this.castMember = data.castMember;
    }

    public submit() {
        this._dialogRef.close(this.castMember);
    }
}
