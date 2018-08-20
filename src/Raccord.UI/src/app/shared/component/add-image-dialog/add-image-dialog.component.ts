import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'add-image-dialog',
  templateUrl: 'add-image-dialog.component.html',
})

export class AddImageDialogComponent {

  constructor(
    private _dialogRef: MatDialogRef<AddImageDialogComponent>,
  ) { }

  public startUpload() {
    const element: HTMLElement = document.getElementById('file-input') as HTMLElement;

    element.click();
  }

  public uploadImage(fileInput: any) {
    this._dialogRef.close({files: fileInput.target.files});
  }
}
