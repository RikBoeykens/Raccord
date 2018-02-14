import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { BreakdownHttpService } from './breakdown-http.service';
import { SelectedBreakdown } from '../model/selected-breakdown.model';
@Injectable()
export class SelectedBreakdownResolve implements Resolve<SelectedBreakdown> {

  constructor(
      private breakdownHttpService: BreakdownHttpService,
      private router: Router
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    let projectId = route.params['projectId'];

    return this.breakdownHttpService.getSelected(projectId).then((breakdown) => {
        if (breakdown) {
            return breakdown;
        } else { // id not found
            this.router.navigate(['/projects', projectId]);
            return false;
        }
    });
  }
}
