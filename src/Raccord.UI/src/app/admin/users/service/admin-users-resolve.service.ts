import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AdminUserHttpService } from './admin-user-http.service';
import { UserSummary } from '../model/user-summary.model';
@Injectable()
export class AdminUsersResolve implements Resolve<UserSummary[]> {

  constructor(
    private _userHttpService: AdminUserHttpService, 
    private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot) {
    return this._userHttpService.getAll().then(data => {
      return data;
    });
  }
}