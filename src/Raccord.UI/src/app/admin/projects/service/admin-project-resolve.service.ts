import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AdminProjectHttpService } from './admin-project-http.service';
import { FullProject } from '../../../projects';
@Injectable()
export class AdminProjectResolve implements Resolve<FullProject> {

  constructor(
      private _projectHttpService: AdminProjectHttpService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot) {
    let id = route.params['projectId'];

    return this._projectHttpService.get(id).then(project => {
      if (project) {
        return project;
      } else { // id not found
        this.router.navigate(['/admin/projects']);
        return false;
      }
    });
  }
}