import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { BreakdownHttpService } from './breakdown-http.service';
import { FullBreakdown } from '../../..';
@Injectable()
export class BreakdownResolve implements Resolve<FullBreakdown> {

  constructor(
    private _breakdownHttpService: BreakdownHttpService
  ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        const projectId = route.params['projectId'];
        const breakdownId = route.params['breakdownId'];
        return this._breakdownHttpService.get(projectId, breakdownId)
            .then((data: FullBreakdown) => data);
    }
}
