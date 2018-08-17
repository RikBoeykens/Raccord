import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { BreakdownSummary } from '../model/breakdown-summary.model';
import { BreakdownHttpService } from './breakdown-http.service';
@Injectable()
export class BreakdownsResolve implements Resolve<BreakdownSummary[]> {

  constructor(
    private _breakdownHttpService: BreakdownHttpService
  ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        const projectId = route.params['projectId'];
        return this._breakdownHttpService.getAll(projectId)
            .then((data: BreakdownSummary[]) => data);
    }
}
