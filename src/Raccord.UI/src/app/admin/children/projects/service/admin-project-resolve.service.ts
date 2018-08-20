import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AdminProjectHttpService } from './admin-project-http.service';
import { AdminFullProject } from '../../..';

@Injectable()
export class AdminProjectResolve implements Resolve<AdminFullProject> {

  constructor(
      private _projectHttpService: AdminProjectHttpService
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    const id = route.params['projectId'];

    return this._projectHttpService.get(id).then((data: AdminFullProject) => data);
  }
}
