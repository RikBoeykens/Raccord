import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ScheduleDayHttpService } from './schedule-day-http.service';
import { FullScheduleDay } from '../model/full-schedule-day.model';
@Injectable()
export class ScheduleDaysResolve implements Resolve<FullScheduleDay[]> {

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