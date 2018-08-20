import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { CreateUser } from '../../../..';

@Component({
  selector: 'admin-add-user-dialog',
  templateUrl: 'admin-add-user-dialog.component.html',
})

export class AdminAddUserDialogComponent {
  public user: CreateUser;

  constructor(
    private _dialogRef: MatDialogRef<AdminAddUserDialogComponent>
  ) {
    this.user = new CreateUser();
  }

  public submit() {
    this._dialogRef.close(this.user);
  }
}
