import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { FullBreakdown } from '../model/full-breakdown.model';
import { BreakdownHttpService } from './breakdown-http.service';
@Injectable()
export class BreakdownResolve implements Resolve<FullBreakdown> {

  constructor(
      private breakdownHttpService: BreakdownHttpService,
      private router: Router
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    let breakdownId = route.params['breakdownId'];
    let projectId = route.params['projectId'];

    return this.breakdownHttpService.get(projectId, breakdownId).then((scheduleScene) => {
        if (scheduleScene) {
            return scheduleScene;
        } else { // id not found
            this.router.navigate(['/projects', projectId]);
            return false;
        }
    });
  }
}
