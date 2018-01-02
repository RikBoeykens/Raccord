import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ProjectHttpService } from './project-http.service';
import { UserProject } from '../model/user-project.model';
@Injectable()
export class ProjectsResolve implements Resolve<UserProject[]> {

  constructor(
    private _projectHttpService: ProjectHttpService, 
    private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot) {
    return this._projectHttpService.getAll().then(data => {
      return data;
    });
  }
}