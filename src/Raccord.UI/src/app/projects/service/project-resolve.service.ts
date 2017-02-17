import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ProjectHttpService } from './project-http.service';
import { FullProject } from '../model/full-project.model';
@Injectable()
export class ProjectResolve implements Resolve<FullProject> {

  constructor(
      private _projectHttpService: ProjectHttpService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot) {
    let id = route.params['projectId'];

    return this._projectHttpService.get(id).then(project => {
      if (project) {
        return project;
      } else { // id not found
        this.router.navigate(['/projects']);
        return false;
      }
    });
  }
}