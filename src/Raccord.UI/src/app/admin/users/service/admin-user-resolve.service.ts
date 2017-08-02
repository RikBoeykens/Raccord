import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AdminUserHttpService } from './admin-user-http.service';
import { FullUser } from '../model/full-user.model';
@Injectable()
export class AdminUserResolve implements Resolve<FullUser> {

  constructor(
      private _userHttpService: AdminUserHttpService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot) {
    let id = route.params['userId'];

    return this._userHttpService.get(id).then(user => {
      if (user) {
        return user;
      } else { // id not found
        this.router.navigate(['/admin/users']);
        return false;
      }
    });
  }
}