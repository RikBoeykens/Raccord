import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ProjectService } from './project.service';
import { ProjectSummary } from '../model/project-summary.model';
@Injectable()
export class ProjectSummaryResolve implements Resolve<ProjectSummary> {

  constructor(
      private projectService: ProjectService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot): Promise<ProjectSummary>|boolean {
    let id = route.params['projectId'];

    return this.projectService.getSummary(id).then(project => {
      if (project) {
        return project;
      } else { // id not found
        this.router.navigate(['/projects']);
        return false;
      }
    });
  }
}