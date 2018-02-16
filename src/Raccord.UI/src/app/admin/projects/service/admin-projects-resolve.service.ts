import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AdminProjectHttpService } from './admin-project-http.service';
import { ProjectSummary } from '../../../projects';
@Injectable()
export class AdminProjectsResolve implements Resolve<ProjectSummary[]> {

  constructor(
    private _projectHttpService: AdminProjectHttpService,
    private router: Router
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    return this._projectHttpService.getAll().then((data) => {
      return data;
    });
  }
}
