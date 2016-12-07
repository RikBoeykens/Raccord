import { Injectable }    from '@angular/core';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';

@Injectable()
export class DialogService{

    constructor(
        private _toastsManager: ToastsManager
    ){}

    confirm(message: string){
        return confirm(message);
    }

    success(message: string){
        this._toastsManager.success(message, null);
    }

    error(message: string){
        this._toastsManager.error(message, null);
    }
}