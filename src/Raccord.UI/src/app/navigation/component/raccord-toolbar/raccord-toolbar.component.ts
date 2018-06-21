import { Component, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../../../security/service/auth.service';
import { Router } from '@angular/router';
import { AccountHelpers } from '../../../shared/children/account';
import { SidenavService } from '../../service/sidenav.service';

@Component({
  selector: 'raccord-toolbar',
  templateUrl: 'raccord-toolbar.component.html',
})
export class RaccordToolbarComponent {

  constructor(
    private _authService: AuthService,
    private _sidenavService: SidenavService,
    private _router: Router
  ) {
  }

  public doToggleMenu() {
    this._sidenavService.toggleSideNav();
  }

  public loggedIn(): boolean {
    return this._authService.loggedIn();
  }

  public getUserId(): string {
    return AccountHelpers.getUserId();
  }

  public getUserName(): string {
    return AccountHelpers.getName();
  }

  public getHasImage(): boolean {
    return AccountHelpers.getHasImage();
  }

  public logOff() {
    this._authService.logout();
    this._router.navigate(['/login']);
  }
}
