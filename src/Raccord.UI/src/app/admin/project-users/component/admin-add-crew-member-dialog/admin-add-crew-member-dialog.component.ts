import { Component, Inject } from '@angular/core';
import { MD_DIALOG_DATA, MdDialogRef } from '@angular/material';
import { CrewMember }
    from '../../../../projects/children/crew/crew-members/model/crew-member.model';
import { CreateUnitCrewMember } from '../../../crew-units/model/create-unit-crew-member.model';
import { CrewDepartment } from '../../../../projects/children/crew/departments/model/crew-department.model';

@Component({
    selector: 'admin-add-crew-member-dialog',
    templateUrl: 'admin-add-crew-member-dialog.component.html',
})

export class AdminAddCrewMemberDialogComponent {

    public crewMember: CreateUnitCrewMember;
    public departments: CrewDepartment[] = [];

    constructor(
        private _dialogRef: MdDialogRef<AdminAddCrewMemberDialogComponent>,
        @Inject(MD_DIALOG_DATA) private data: {
            crewMember: CreateUnitCrewMember,
            departments: CrewDepartment[]
        }
    ) {
        this.crewMember = data.crewMember;
        this.departments = data.departments;
    }

    public submit() {
        this._dialogRef.close(this.crewMember);
    }
}
