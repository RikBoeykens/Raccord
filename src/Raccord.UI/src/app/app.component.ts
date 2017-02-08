/*
 * Angular 2 decorators and services
 */
import {
  Component
} from '@angular/core';
import { Router, NavigationStart, NavigationEnd, NavigationCancel, NavigationError, Event as RouterEvent } from '@angular/router';
import { LoadingService } from './loading/service/loading.service';

/*
 * App Component
 * Top Level Component
 */
@Component({
  selector: 'app',
  styleUrls: [
    './app.component.css'
  ],
  templateUrl: 'app.component.html'
})
export class AppComponent{

    loadingId: string;

    constructor(
        private _router: Router,
        private _loadingService: LoadingService
    ) {
        _router.events.subscribe((event: RouterEvent) => {
            this.navigationInterceptor(event);
        });
    }

    navigationInterceptor(event: RouterEvent): void {
        if (event instanceof NavigationStart) {
            this.loadingId = this._loadingService.startLoading();
        }
        if (event instanceof NavigationEnd) {
            this._loadingService.endLoading(this.loadingId);
        }

        // Set loading state to false in both of the below events to hide the spinner in case a request fails
        if (event instanceof NavigationCancel) {
            this._loadingService.endLoading(this.loadingId);
        }
        if (event instanceof NavigationError) {
            this._loadingService.endLoading(this.loadingId);
        }
    }
}