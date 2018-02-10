import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { BreakdownTypeHttpService } from './breakdown-type-http.service';
import { FullBreakdownType } from '../model/full-breakdown-type.model';
@Injectable()
export class BreakdownTypeResolve implements Resolve<FullBreakdownType> {

  constructor(
      private _breakdownTypeHttpService: BreakdownTypeHttpService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot) {
    let breakdownTypeId = route.params['breakdownTypeId'];

    return this._breakdownTypeHttpService.get(breakdownTypeId).then(breakdownType => {
        if (breakdownType) {
            return breakdownType;
        } else { // id not found
            let projectId = route.params['projectId'];
            this.router.navigate(['/projects', projectId]);
            return false;
        }
    });
  }
}