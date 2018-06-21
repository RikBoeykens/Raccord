import { Component } from '@angular/core';
import { LoadingService } from '../service/loading.service';

@Component({
    selector: 'raccord-loading',
    templateUrl: 'loading.component.html',
})
export class LoadingComponent {
    public showLoader: boolean = false;

    constructor(
        private _loadingService: LoadingService
    ) {
        _loadingService.toggleLoading$.subscribe((show) => {
            this.showLoader = show;
        });
    }
}
