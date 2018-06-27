import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ProjectSummary } from '../../../../shared/children/projects';
import { AdminProjectHttpService } from './admin-project-http.service';

@Injectable()
export class AdminProjectsResolve implements Resolve<ProjectSummary[]> {

  constructor(
      private _projectHttpService: AdminProjectHttpService
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    return this._projectHttpService.getAll().then((data: ProjectSummary[]) => data);
  }
}
