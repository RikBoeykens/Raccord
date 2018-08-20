import { Injectable } from '@angular/core';
import { MatSnackBar, MatDialog } from '@angular/material';
import { ConfirmDialogComponent } from '../component/confirm-dialog/confirm-dialog.component';

@Injectable()
export class DialogService {

    constructor(
        private _snackBar: MatSnackBar,
        private _dialog: MatDialog
    ) {}

    public confirm(message: string, onConfirm?: () => void, onCancel?: () => void) {
        const confirmDialog = this._dialog.open(ConfirmDialogComponent, {data:
        {
            confirmText: message
        }});
        confirmDialog.afterClosed().subscribe((confirmed: boolean) => {
            if (confirmed && onConfirm) {
                onConfirm();
            } else if (!confirmed && onCancel) {
                onCancel();
            }
        });
    }

    public success(message: string) {
        this._snackBar.open(message, null, {duration: 3000});
    }

    public error(message: string) {
        this._snackBar.open(message, null, {duration: 3000});
    }
}
