import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { BreakdownItemHttpService } from './breakdown-item-http.service';
import { FullBreakdownItem } from '../model/full-breakdown-item.model';
@Injectable()
export class BreakdownItemResolve implements Resolve<FullBreakdownItem> {

  constructor(
      private _breakdownItemHttpService: BreakdownItemHttpService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot) {
    let breakdownItemId = route.params['breakdownItemId'];

    return this._breakdownItemHttpService.get(breakdownItemId).then(item => {
        if (item) {
            return item;
        } else { // id not found
            let projectId = route.params['projectId'];
            this.router.navigate(['/projects', projectId]);
            return false;
        }
    });
  }
}