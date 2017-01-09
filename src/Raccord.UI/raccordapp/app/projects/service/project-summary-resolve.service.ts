import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ProjectHttpService } from './project-http.service';
import { ProjectSummary } from '../model/project-summary.model';
@Injectable()
export class ProjectSummaryResolve implements Resolve<ProjectSummary> {

  constructor(
      private _projectHttpService: ProjectHttpService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot): Promise<ProjectSummary>|boolean {
    let id = route.params['projectId'];

    return this._projectHttpService.getSummary(id).then(project => {
      if (project) {
        return project;
      } else { // id not found
        this.router.navigate(['/projects']);
        return false;
      }
    });
  }
}