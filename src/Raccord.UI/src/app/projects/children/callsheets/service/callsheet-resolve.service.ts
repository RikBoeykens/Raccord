import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { CallsheetHttpService } from './callsheet-http.service';
import { FullCallsheet } from '../';
@Injectable()
export class CallsheetResolve implements Resolve<FullCallsheet> {

  constructor(
      private _callsheetHttpService: CallsheetHttpService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot) {
    let callsheetId = route.params['callsheetId'];

    return this._callsheetHttpService.get(callsheetId).then(callsheet => {
        if (callsheet) {
            return callsheet;
        } else { // id not found
            let projectId = route.params['projectId'];
            this.router.navigate(['/projects', projectId]);
            return false;
        }
    });
  }
}