import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { DayNightService } from './day-night.service';
import { DayNightSummary } from '../model/day-night-summary.model';
@Injectable()
export class DayNightsResolve implements Resolve<DayNightSummary[]> {

  constructor(
    private dayNightService: DayNightService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot): Promise<DayNightSummary[]>|boolean {
        let projectId = route.params['projectId'];
        return this.dayNightService.getAll(projectId).then(data => {
            return data;
        });
    }
}