import { Injectable } from '@angular/core';
import { LoadingService } from '../../loading/service/loading.service';
import { DialogService } from './dialog.service';

@Injectable()
export class LoadingWrapperService {

    constructor(
        private _loadingService: LoadingService,
        private _dialogService: DialogService
    ) {}

    public Load(loadFunction: Promise<any>, onLoaded?: (data) => void, onFinally?: () => void) {
      this._loadingService.startLoading();
      loadFunction.then((data) => {
        if (data && data.hasError) {
          this._dialogService.error(data.message);
        } else {
          if (onLoaded) {
            onLoaded(data);
          }
        }
        this._loadingService.endLoading();
        if (onFinally) {
          onFinally();
        }
      }).catch((err) => {
        this._dialogService.error('Something went wrong');
        this._loadingService.endLoading();
        if (onFinally) {
          onFinally();
        }
      });
    }
}
