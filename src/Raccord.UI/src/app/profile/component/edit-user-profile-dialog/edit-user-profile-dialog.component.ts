import { Component, Inject } from '@angular/core';
import { MD_DIALOG_DATA, MdDialogRef } from '@angular/material';
import { UserProfile } from '../../model/user-profile.model';

@Component({
    selector: 'edit-user-profile-dialog',
    templateUrl: 'edit-user-profile-dialog.component.html',
})

export class EditUserProfileDialog {

    public userProfile: UserProfile;

    constructor(
        private _dialogRef: MdDialogRef<EditUserProfileDialog>,
        @Inject(MD_DIALOG_DATA) private data: {
            userProfile: UserProfile
        }
    ) {
        this.userProfile = data.userProfile;
    }

    public submit() {
        this._dialogRef.close(this.userProfile);
    }
}
