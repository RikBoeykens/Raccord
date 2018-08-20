import { Injectable } from '@angular/core';
import { ProjectRole } from '../../../../shared/children/users';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AdminProjectRoleHttpService } from './admin-project-role-http.service';

@Injectable()
export class AdminProjectRolesResolve implements Resolve<ProjectRole[]> {

  constructor(
    private _projectRoleHttpService: AdminProjectRoleHttpService,
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    return this._projectRoleHttpService.get().then((data: ProjectRole[]) => data);
  }
}
