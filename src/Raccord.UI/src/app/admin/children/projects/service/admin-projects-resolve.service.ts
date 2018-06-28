import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AdminProjectHttpService } from './admin-project-http.service';
import { AdminProjectSummary } from '../../..';

@Injectable()
export class AdminProjectsResolve implements Resolve<AdminProjectSummary[]> {

  constructor(
      private _projectHttpService: AdminProjectHttpService
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    return this._projectHttpService.getAll().then((data: AdminProjectSummary[]) => data);
  }
}
