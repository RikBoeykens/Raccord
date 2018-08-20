import { Injectable } from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { BreakdownTypeHttpService } from './breakdown-type-http.service';
import { BreakdownTypeSummary } from '../../../../..';

@Injectable()
export class BreakdownTypesResolve implements Resolve<BreakdownTypeSummary[]> {

  constructor(
    private _breakdownTypeHttpService: BreakdownTypeHttpService
  ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        const breakdownId = route.params['breakdownId'];
        return this._breakdownTypeHttpService.getAllForBreakdown(breakdownId)
            .then((data: BreakdownTypeSummary[]) => data);
    }
}
