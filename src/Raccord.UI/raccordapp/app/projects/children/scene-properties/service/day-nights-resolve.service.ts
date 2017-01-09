import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { DayNightHttpService } from './day-night-http.service';
import { DayNightSummary } from '../model/day-night-summary.model';
@Injectable()
export class DayNightsResolve implements Resolve<DayNightSummary[]> {

  constructor(
    private dayNightHttpService: DayNightHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot): Promise<DayNightSummary[]>|boolean {
        let projectId = route.params['projectId'];
        return this.dayNightHttpService.getAll(projectId).then(data => {
            return data;
        });
    }
}