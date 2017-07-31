import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CallsheetHttpService } from './callsheet-http.service';
import { CallsheetSummary } from '../';
@Injectable()
export class CallsheetsResolve implements Resolve<CallsheetSummary[]> {

  constructor(
    private _callsheetHttpService: CallsheetHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let projectId = route.params['projectId'];
        return this._callsheetHttpService.getAll(projectId).then(data => {
            return data;
        });
    }
}