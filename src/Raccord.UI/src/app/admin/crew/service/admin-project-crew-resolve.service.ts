import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AdminCrewHttpService } from './admin-crew-http.service';
import { CrewUserUser } from "../model/crew-user-user.model";

@Injectable()
export class AdminProjectCrewResolve implements Resolve<CrewUserUser[]> {

  constructor(
    private _callsheetSceneHttpService: AdminCrewHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let projectId = route.params['projectId'];
        return this._callsheetSceneHttpService.getUsers(projectId).then(data => {
            return data;
        });
    }
}