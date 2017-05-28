import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ScheduleDayHttpService } from './schedule-day-http.service';
import { ScheduleDaySummary } from '../model/schedule-day-summary.model';
@Injectable()
export class ScheduleDaysResolve implements Resolve<ScheduleDaySummary[]> {

  constructor(
    private scheduleDayHttpService: ScheduleDayHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let projectId = route.params['projectId'];
        return this.scheduleDayHttpService.getAll(projectId).then(data => {
            return data;
        });
    }
}