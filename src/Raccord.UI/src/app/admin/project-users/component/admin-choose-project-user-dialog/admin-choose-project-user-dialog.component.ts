import { Component, Inject } from '@angular/core';
import { MD_DIALOG_DATA, MdDialogRef } from '@angular/material';
import { ProjectUserUser } from '../../model/project-user-user.model';

@Component({
    selector: 'admin-choose-project-user-dialog',
    templateUrl: 'admin-choose-project-user-dialog.component.html',
})

export class AdminChooseProjectUserDialogComponent {

    public projectUsers: ProjectUserUser[];

    constructor(
        private _dialogRef: MdDialogRef<AdminChooseProjectUserDialogComponent>,
        @Inject(MD_DIALOG_DATA) private data: {
            projectUsers: ProjectUserUser[]
        }
    ) {
        this.projectUsers = data.projectUsers;
    }

    public chooseProjectUser(projectUser: ProjectUserUser) {
        this._dialogRef.close(projectUser);
    }

    public getFullName(projectUser: ProjectUserUser) {
        return `${projectUser.user.firstName} ${projectUser.user.lastName}`;
    }
}
