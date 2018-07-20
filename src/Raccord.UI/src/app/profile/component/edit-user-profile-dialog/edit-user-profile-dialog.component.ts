import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { UserProfile } from '../../../shared/children/users';

@Component({
  selector: 'edit-user-profile-dialog',
  templateUrl: 'edit-user-profile-dialog.component.html',
})

export class EditUserProfileDialogComponent {
  public userProfile: UserProfile;

  constructor(
    private _dialogRef: MatDialogRef<EditUserProfileDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: {
        userProfile: UserProfile
    }
  ) {
    this.userProfile = data.userProfile;
  }

  public submit() {
    this._dialogRef.close({userProfile: this.userProfile});
  }
}
