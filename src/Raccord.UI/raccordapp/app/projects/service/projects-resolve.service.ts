import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ProjectHttpService } from './project-http.service';
import { ProjectSummary } from '../model/project-summary.model';
@Injectable()
export class ProjectsResolve implements Resolve<ProjectSummary[]> {

  constructor(
    private _projectHttpService: ProjectHttpService, 
    private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot): Promise<ProjectSummary[]>|boolean {
    return this._projectHttpService.getAll().then(data => {
      return data;
    });
  }
}