import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AdminProjectUserHttpService } from './admin-project-user-http.service';
import { AdminFullProjectUser } from '../model/admin-full-project-user.model';

@Injectable()
export class AdminProjectUserResolve implements Resolve<AdminFullProjectUser> {

  constructor(
      private _projectUserHttpService: AdminProjectUserHttpService
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    const id = route.params['projectUserId'];

    return this._projectUserHttpService.get(id).then((data: AdminFullProjectUser) => data);
  }
}
