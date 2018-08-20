import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { BreakdownTypeHttpService } from './breakdown-type-http.service';
import { FullBreakdownType } from '../../../../..';

@Injectable()
export class BreakdownTypeResolve implements Resolve<FullBreakdownType> {

  constructor(
      private _breakdownTypeHttpService: BreakdownTypeHttpService
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    const breakdownTypeId = route.params['breakdownTypeId'];

    return this._breakdownTypeHttpService.get(breakdownTypeId)
        .then((data: FullBreakdownType) => data);
  }
}
