import { Injectable }    from '@angular/core';
import { MdSnackBar } from '@angular/material';
import { LoadingService } from '../../loading/service/loading.service';
import { DialogService } from './dialog.service';

@Injectable()
export class LoadingWrapperService {

    constructor(
        private _loadingService: LoadingService,
        private _dialogService: DialogService
    ) {}

    public Load(loadFunction: Promise<any>, onLoaded?: Function, onFinally?: Function) {
      let loadingId = this._loadingService.startLoading();
      loadFunction.then((data) => {
        if (typeof(data) === 'string') {
          this._dialogService.error(data);
        }else {
          if (onLoaded) {
            onLoaded(data);
          }
        }
        this._loadingService.endLoading(loadingId);
        if (onFinally) {
          onFinally();
        }
      }).catch((err) => {
        this._dialogService.error('Something went wrong');
        this._loadingService.endLoading(loadingId);
        if (onFinally) {
          onFinally();
        }
      });
    }
}
