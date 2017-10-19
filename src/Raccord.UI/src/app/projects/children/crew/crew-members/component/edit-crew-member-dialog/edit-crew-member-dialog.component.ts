import { Component, Inject } from '@angular/core';
import { MD_DIALOG_DATA, MdDialogRef } from '@angular/material';
import { CrewMember } from '../../model/crew-member.model';
import { CrewDepartment } from '../../../departments/model/crew-department.model';

@Component({
    selector: 'edit-crew-member-dialog',
    templateUrl: 'edit-crew-member-dialog.component.html',
})

export class EditCrewMemberDialog {

    public crewMember: CrewMember;
    public availableDepartments: CrewDepartment[];

    constructor(
        private _dialogRef: MdDialogRef<EditCrewMemberDialog>,
        @Inject(MD_DIALOG_DATA) private data: {
            crewMember: CrewMember,
            availableDepartments: CrewDepartment[]
        }
    ) {
        this.crewMember = data.crewMember;
        this.availableDepartments = data.availableDepartments;
    }

    public submit() {
        this._dialogRef.close(this.crewMember);
    }
}
