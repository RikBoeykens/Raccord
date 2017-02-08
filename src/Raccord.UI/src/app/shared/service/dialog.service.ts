import { Injectable }    from '@angular/core';
import {MdSnackBar} from '@angular/material';

@Injectable()
export class DialogService{

    constructor(
        public _snackBar: MdSnackBar
    ){}

    confirm(message: string){
        return confirm(message);
    }

    success(message: string){
        this._snackBar.open(message);
    }

    error(message: string){
        this._snackBar.open(message);
    }
}