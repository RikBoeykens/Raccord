import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AdminCrewHttpService } from './admin-crew-http.service';
import { CrewUserProject } from "../model/crew-user-project.model";

@Injectable()
export class AdminUserProjectsResolve implements Resolve<CrewUserProject[]> {

  constructor(
    private _callsheetSceneHttpService: AdminCrewHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let userId = route.params['userId'];
        return this._callsheetSceneHttpService.getProjects(userId).then(data => {
            return data;
        });
    }
}