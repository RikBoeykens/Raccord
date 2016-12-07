import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ProjectService } from './project.service';
import { Project } from '../model/project.model';
@Injectable()
export class ProjectResolve implements Resolve<Project> {

  constructor(
      private projectService: ProjectService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot): Promise<Project>|boolean {
    let id = route.params['projectId'];

    return this.projectService.get(id).then(project => {
      if (project) {
        return project;
      } else { // id not found
        this.router.navigate(['/projects']);
        return false;
      }
    });
  }
}