import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ProjectUserProject } from '../model/project-user-project.model';
import { AdminProjectUserHttpService } from './admin-project-user-http.service';

@Injectable()
export class AdminUserProjectsResolve implements Resolve<ProjectUserProject[]> {

  constructor(
    private _projectUserHttpService: AdminProjectUserHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let userId = route.params['userId'];
        return this._projectUserHttpService.getProjects(userId).then(data => {
            return data;
        });
    }
}