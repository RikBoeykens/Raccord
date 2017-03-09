import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { BreakdownTypeHttpService } from './breakdown-type-http.service';
import { BreakdownTypeSummary } from '../model/breakdown-type-summary.model';
@Injectable()
export class BreakdownTypesResolve implements Resolve<BreakdownTypeSummary[]> {

  constructor(
    private _breakdownTypeHttpService: BreakdownTypeHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let projectId = route.params['projectId'];
        return this._breakdownTypeHttpService.getAll(projectId).then(data => {
            return data;
        });
    }
}