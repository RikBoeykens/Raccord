import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ProjectService } from './project.service';
import { ProjectSummary } from '../model/project-summary.model';
@Injectable()
export class ProjectsResolve implements Resolve<ProjectSummary[]> {

  constructor(
    private projectService: ProjectService, 
    private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot): Promise<ProjectSummary[]>|boolean {
    return this.projectService.getAll().then(data => {
      return data;
    });
  }
}