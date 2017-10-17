import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AdminProjectUserHttpService } from './admin-project-user-http.service';
import { ProjectUserUser } from '../model/project-user-user.model';

@Injectable()
export class AdminProjectUsersResolve implements Resolve<ProjectUserUser[]> {

  constructor(
    private _projectUserHttpService: AdminProjectUserHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let projectId = route.params['projectId'];
        return this._projectUserHttpService.getUsers(projectId).then(data => {
            return data;
        });
    }
}