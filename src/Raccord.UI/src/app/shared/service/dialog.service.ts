import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material';

@Injectable()
export class DialogService {

    constructor(
        public _snackBar: MatSnackBar
    ) {}

    public confirm(message: string) {
        return confirm(message);
    }

    public success(message: string) {
        this._snackBar.open(message, null, {duration: 3000});
    }

    public error(message: string) {
        this._snackBar.open(message, null, {duration: 3000});
    }
}
