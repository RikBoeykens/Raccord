import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { FullProject } from '../../../../shared/children/projects';
import { AdminProjectHttpService } from './admin-project-http.service';

@Injectable()
export class AdminProjectResolve implements Resolve<FullProject> {

  constructor(
      private _projectHttpService: AdminProjectHttpService
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    const id = route.params['projectId'];

    return this._projectHttpService.get(id).then((data: FullProject) => data);
  }
}
