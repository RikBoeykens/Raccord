import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CallsheetHttpService } from './callsheet-http.service';
import { CallsheetCrewUnit } from '../model/callsheet-crew-unit.model';
@Injectable()
export class CallsheetsResolve implements Resolve<CallsheetCrewUnit[]> {

  constructor(
    private _callsheetHttpService: CallsheetHttpService,
    private router: Router
  ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        let projectId = route.params['projectId'];
        return this._callsheetHttpService.getAllForProject(projectId).then((data) => {
            return data;
        });
    }
}
