import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AdminUserHttpService } from './admin-user-http.service';
import { AdminUserSummary } from '../../..';

@Injectable()
export class AdminUsersResolve implements Resolve<AdminUserSummary[]> {

  constructor(
      private _userHttpService: AdminUserHttpService
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    return this._userHttpService.getAll().then((data: AdminUserSummary[]) => data);
  }
}
