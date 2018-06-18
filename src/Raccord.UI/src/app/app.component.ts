/**
 * Angular 2 decorators and services
 */
import { Component } from '@angular/core';
import { AuthService } from './security/service/auth.service';
import { Router, RouterEvent, NavigationStart, NavigationEnd,
  NavigationCancel, NavigationError } from '@angular/router';
import { LoadingService } from './loading/service/loading.service';

/**
 * App Component
 * Top Level Component
 */
@Component({
  selector: 'app',
  templateUrl: 'app.component.html'
})
export class AppComponent {
  public opened: boolean = true;
  private _loadingId: string;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _loadingService: LoadingService
  ) {
    _router.events.subscribe((event: RouterEvent) => {
        this.navigationInterceptor(event);
    });
  }

  public toggleMenu() {
    this.opened = !this.opened;
  }

  public loggedIn(): boolean {
    return this._authService.loggedIn();
  }

  private navigationInterceptor(event: RouterEvent): void {
      if (event instanceof NavigationStart) {
          this._loadingId = this._loadingService.startLoading();
      }
      if (event instanceof NavigationEnd) {
          this._loadingService.endLoading(this._loadingId);
      }

      if (event instanceof NavigationCancel) {
          this._loadingService.endLoading(this._loadingId);
      }
      if (event instanceof NavigationError) {
          this._loadingService.endLoading(this._loadingId);
      }
  }
}
