import { Component, Inject } from '@angular/core';
import { MD_DIALOG_DATA, MdDialogRef } from '@angular/material';
import { CastMember } from '../../model/cast-member.model';

@Component({
    selector: 'edit-cast-member-dialog',
    templateUrl: 'edit-cast-member-dialog.component.html',
})

export class EditCastMemberDialogComponent {

    public castMember: CastMember;

    constructor(
        private _dialogRef: MdDialogRef<EditCastMemberDialogComponent>,
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
