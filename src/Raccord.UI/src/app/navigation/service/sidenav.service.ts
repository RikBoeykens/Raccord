import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';
@Injectable()
export class SidenavService {

  public toggleSidenavSource = new Subject<boolean>();
  public toggleSidenav$ = this.toggleSidenavSource.asObservable();
  private showSideNav: boolean = false;

  public toggleSideNav() {
    this.showSideNav = !this.showSideNav;
    this.toggleSidenavSource.next(this.showSideNav);
  }

  public setShowSideNav() {
    this.showSideNav = true;
    this.toggleSidenavSource.next(this.showSideNav);
  }

  public setHideSideNav() {
    this.showSideNav = false;
    this.toggleSidenavSource.next(this.showSideNav);
  }
}
