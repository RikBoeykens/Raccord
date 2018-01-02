import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AdminProjectUserHttpService } from './admin-project-user-http.service';
import { FullProjectUser } from '../model/full-project-user.model';

@Injectable()
export class AdminProjectUserResolve implements Resolve<FullProjectUser> {

  constructor(
    private _projectUserHttpService: AdminProjectUserHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let projectUserId = route.params['projectUserId'];
        return this._projectUserHttpService.get(projectUserId).then(data => {
            return data;
        });
    }
}