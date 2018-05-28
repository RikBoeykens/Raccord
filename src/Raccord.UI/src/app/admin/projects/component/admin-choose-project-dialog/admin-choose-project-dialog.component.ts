import { Component, Inject } from '@angular/core';
import { MD_DIALOG_DATA, MdDialogRef } from '@angular/material';
import { ProjectRole } from '../../../project-roles/model/project-role.model';
import { Project } from '../../../../projects/model/project.model';

@Component({
    selector: 'admin-choose-project-dialog',
    templateUrl: 'admin-choose-project-dialog.component.html',
})

export class AdminChooseProjectDialogComponent {
    public availableRoles: ProjectRole[] = [];
    public chosenRoleId: number;
    public searchProject: Project = new Project();

    constructor(
        private _dialogRef: MdDialogRef<AdminChooseProjectDialogComponent>,
        @Inject(MD_DIALOG_DATA) private data: {
            projectRoles: ProjectRole[]
        }
    ) {
        this.availableRoles = data.projectRoles;
    }

    public submit() {
        this._dialogRef.close({chosenRoleId: this.chosenRoleId, projectId: this.searchProject.id});
    }
}
