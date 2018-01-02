import { Component, Inject } from '@angular/core';
import { MD_DIALOG_DATA, MdDialogRef } from '@angular/material';
import { CrewMember } from '../../../../projects/children/crew/crew-members/model/crew-member.model';

@Component({
    selector: 'admin-edit-crew-member-dialog',
    templateUrl: 'admin-edit-crew-member-dialog.component.html',
})

export class AdminEditCrewMemberDialog {

    public crewMember: CrewMember;

    constructor(
        private _dialogRef: MdDialogRef<AdminEditCrewMemberDialog>,
        @Inject(MD_DIALOG_DATA) private data: {
            crewMember: CrewMember
        }
    ) {
        this.crewMember = data.crewMember;
    }

    public submit() {
        this._dialogRef.close(this.crewMember);
    }
}
