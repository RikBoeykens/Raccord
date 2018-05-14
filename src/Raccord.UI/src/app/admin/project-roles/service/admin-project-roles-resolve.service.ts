import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AdminProjectRoleHttpService } from './admin-project-role-http.service';
import { ProjectRole } from '../model/project-role.model';

@Injectable()
export class AdminProjectRolesResolve implements Resolve<ProjectRole[]> {

  constructor(
    private _projectRoleHttpService: AdminProjectRoleHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        return this._projectRoleHttpService.get().then(data => {
            return data;
        });
    }
}