import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { BreakdownItemHttpService } from './breakdown-item-http.service';
import { BreakdownItemSummary } from '../model/breakdown-item-summary.model';
@Injectable()
export class BreakdownItemsResolve implements Resolve<BreakdownItemSummary[]> {

  constructor(
    private _breakdownItemHttpService: BreakdownItemHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let typeId = route.params['breakdownTypeId'];
        return this._breakdownItemHttpService.getAll(typeId).then(data => {
            return data;
        });
    }
}