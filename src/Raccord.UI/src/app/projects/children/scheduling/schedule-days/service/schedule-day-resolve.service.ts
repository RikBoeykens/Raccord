import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ScheduleDayHttpService } from './schedule-day-http.service';
import { FullScheduleDay } from '../model/full-schedule-day.model';
@Injectable()
export class ScheduleDayResolve implements Resolve<FullScheduleDay> {

  constructor(
      private scheduleDayHttpService: ScheduleDayHttpService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot) {
    let scheduleDayId = route.params['scheduleDayId'];

    return this.scheduleDayHttpService.get(scheduleDayId).then(day => {
        if (day) {
            return day;
        } else { // id not found
            let projectId = route.params['projectId'];
            this.router.navigate(['/projects', projectId]);
            return false;
        }
    });
  }
}