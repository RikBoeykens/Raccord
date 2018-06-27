import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'confirm-dialog',
  templateUrl: 'confirm-dialog.component.html',
})

export class ConfirmDialogComponent {
  public confirmText: string;

  constructor(
    private _dialogRef: MatDialogRef<ConfirmDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: {
      confirmText: string
    }
  ) {
    this.confirmText = data.confirmText;
  }

  public submit() {
    this._dialogRef.close(true);
  }
}
