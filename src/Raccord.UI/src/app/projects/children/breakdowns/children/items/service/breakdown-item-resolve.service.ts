import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { BreakdownItemHttpService } from './breakdown-item-http.service';
import { FullBreakdownItem } from '../../../../..';

@Injectable()
export class BreakdownItemResolve implements Resolve<FullBreakdownItem> {

  constructor(
      private _breakdownItemHttpService: BreakdownItemHttpService
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    const breakdownItemId = route.params['breakdownItemId'];

    return this._breakdownItemHttpService.get(breakdownItemId)
        .then((data: FullBreakdownItem) => data);
  }
}
