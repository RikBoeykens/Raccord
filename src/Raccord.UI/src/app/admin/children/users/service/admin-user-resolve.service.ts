import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AdminFullUser } from '../../..';
import { AdminUserHttpService } from './admin-user-http.service';

@Injectable()
export class AdminUserResolve implements Resolve<AdminFullUser> {

  constructor(
      private _userHttpService: AdminUserHttpService
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    const id = route.params['userId'];

    return this._userHttpService.get(id).then((data: AdminFullUser) => data);
  }
}
