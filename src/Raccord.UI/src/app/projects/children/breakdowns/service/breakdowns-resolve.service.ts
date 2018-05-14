import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { BreakdownSummary } from '../model/breakdown-summary.model';
import { BreakdownHttpService } from './breakdown-http.service';
@Injectable()
export class BreakdownsResolve implements Resolve<BreakdownSummary[]> {

  constructor(
    private _breakdownHttpService: BreakdownHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let projectId = route.params['projectId'];
        return this._breakdownHttpService.getAll(projectId).then(data => {
            return data;
        });
    }
}