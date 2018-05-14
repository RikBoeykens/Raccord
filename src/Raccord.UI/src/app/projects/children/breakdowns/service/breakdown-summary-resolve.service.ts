import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { BreakdownHttpService } from './breakdown-http.service';
import { BreakdownSummary } from '../model/breakdown-summary.model';

@Injectable()
export class BreakdownSummaryResolve implements Resolve<BreakdownSummary> {

  constructor(
      private breakdownHttpService: BreakdownHttpService,
      private router: Router
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    let breakdownId = route.params['breakdownId'];
    let projectId = route.params['projectId'];

    return this.breakdownHttpService.getSummary(projectId, breakdownId).then((scheduleScene) => {
        if (scheduleScene) {
            return scheduleScene;
        } else { // id not found
            this.router.navigate(['/projects', projectId]);
            return false;
        }
    });
  }
}
